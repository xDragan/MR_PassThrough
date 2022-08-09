using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*		1		 */
	//	Necesitamos un collider para que funcione
	[RequireComponent(typeof(Collider))]
/*		1		 */

public class XRButton : MonoBehaviour {

	/*		2		 */
		//	Tendremos dos eventos uno al seleccionar y otro al deseleccionar
		public UnityEvent on_selected_event;
		public UnityEvent on_unselected_event;
		public UnityEvent on_fire_event;
	/*		2		 */

	/*		3		 */
		//	Almacenaremos el estado actual
		bool state = false;

		//	Que mando ha interactuado
		public GameObject controller = null;
	/*		3		 */

	/*		4		 */
		//	Al entrar en el collider
		public void OnTriggerEnter(Collider other) {
			//	comprobamos que no estuviera seleccionado
			if(state)	return;

			//	comprobamos que el otro objeto es un mando
			if( other.gameObject.tag != "xr_controller" )	return;

			//	asignamos el estado actual
			controller = other.gameObject;
			state = true;

			//	Propagamos el evento
			on_selected_event?.Invoke();
		}
		
		//	Al salir del collider
		public void OnTriggerExit(Collider other) {
			//	comprobamos que estuviera seleccionado
			if(!state)	return;

			//	comprobamos que el otro objeto es un mando y que es el que teniamos almacenado
			if( other.gameObject.tag != "xr_controller" )	return;
			if(controller != null && controller != other.gameObject)	return;

			//	asignamos el estado actual
			state = false;

			//	Propagamos el evento
			on_unselected_event?.Invoke();
		}

		public void OnSelect(GameObject _controller) {
			//	comprobamos que no estuviera seleccionado
			if(state)	return;


			//	asignamos el estado actual
			controller = _controller;
			state = true;

			//	Propagamos el evento
			on_selected_event?.Invoke();
		}
		
		//	Al salir del collider
		public void OnDeselect(GameObject _controller) {
			//	comprobamos que estuviera seleccionado
			if(!state)	return;

			//	comprobamos que el otro objeto es un mando y que es el que teniamos almacenado
			if(controller != null && controller != _controller)	return;

			//	asignamos el estado actual
			state = false;

			//	Propagamos el evento
			on_unselected_event?.Invoke();
		}


		public void FireEvent(GameObject _controller){
			//	Deseleccionamos el objeto
			OnDeselect(_controller);

			//	Llamamos la acción
			on_fire_event?.Invoke();

		}
	/*		4		 */


}
