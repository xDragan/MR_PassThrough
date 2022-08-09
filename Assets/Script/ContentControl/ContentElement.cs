using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*		2		 */
    //  Importamos la biblioteca de eventos
    using UnityEngine.Events;
/*		2		 */

public class ContentElement : MonoBehaviour{

    #region eventos
        /*		3		 */
            //  creamos eventos donde controlaremos lo que pasa cuando mostramos u ocultamos el contenido
            public UnityEvent on_show_content;
            public UnityEvent on_hide_content;
        /*		3		 */
    #endregion eventos


    #region mono
        /*		1		 */
            //  Este elemento se subscribirá al controlador al crearse y se quitara al destruirse
            void Start(){
                ContentControl.Instance.on_hide_content += Disable;
                Disable();
            }

            void OnDestroy(){
                ContentControl.Instance.on_hide_content -= Disable;
            }
        /*		1		 */
    #endregion  // mono

    #region action
        /*		4		 */
            //  funciones publicas que llamaremos para cargar ocultar un contenido
            public void OpenContent(){
                ContentControl.Instance.LoadContent(this);
            }
            public void CloseContent(){
                ContentControl.Instance.UnloadContent();
            }
        /*		4		 */
    #endregion  // action

    #region content
        /*		5		 */
            //  funciones de uso internas que solo deben llamarse desde el ContentControl
            public void Enable(){
                on_show_content?.Invoke();
            }

            public void Disable(){
                on_hide_content?.Invoke();
            }
        /*		5		 */
    #endregion  // content
}
