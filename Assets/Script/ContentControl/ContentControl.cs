using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentControl : MonoBehaviour{
    

	/*		1		 */
        //  Callback para los eventos
        public delegate void CallbackDelegate();

		//	Eventos
		public event CallbackDelegate on_hide_content = null;
        // public event CallbackDelegate on_show_content = null;
	/*		1		 */

    public static ContentControl Instance = null;

    #region mono
	/*		2		 */
        //  Importante la instncia asignada en este caso, ya que se portara como transmisor de los eventos
        void Awake(){
            Instance = this;
        }
	/*		2		 */
    #endregion  // mono

    #region content
    /*		3		 */
        //  gestionamos que contenido se muestra
        public void LoadContent(ContentElement element){
            //  ocultamos los contenidos activos
            on_hide_content?.Invoke();
            //  mostramos el nuevo
            element.Enable();
        }

        //  ocultamos todos los contenidos
        public void UnloadContent(){
            on_hide_content?.Invoke();
        }
    /*		3		 */
    #endregion  // content
}
