using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRInputController : MonoBehaviour {

/*		1		 */
	//	Que mandos queremos comprobar
	[Header("Comprobaciones")]
	public bool check_left_controller = true;
	public bool check_right_controller = true;
/*		1		 */


/*		2		 */
	//	Creamos un objeto para cada mando
	[Header("Eventos para cada controlador")]
	public XRInputEvents left_input;
	public XRInputEvents right_input;
/*		2		 */

/*		4		 */
	bool was_double_grip = false;
	public XRButtonEvent on_double_grip_pressed;
/*		4		 */
	
	void Update () {
		/*		3		 */
			//	PAra cada mando comprobamos el touchpad, el trigger, el grip, y el menu
			if(check_left_controller){
				left_input.CheckThumbnail(true);
				left_input.CheckTrigger(true);
				left_input.CheckGrip(true);
				left_input.CheckMenu(true);
			}

			if(check_right_controller){
				right_input.CheckThumbnail(false);
				right_input.CheckTrigger(false);
				right_input.CheckGrip(false);
				// aqui no comprobamos menú, es un botón reservado
			}

		/*		3		 */
		
		/*		5		 */
			bool is_double_grip = left_input.IsGrip && right_input.IsGrip;
			if(is_double_grip && ! was_double_grip)	on_double_grip_pressed?.Invoke();
			was_double_grip = is_double_grip;
		/*		5		 */
	}


}
