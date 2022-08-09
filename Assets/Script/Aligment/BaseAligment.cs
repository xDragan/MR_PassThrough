using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAligment : MonoBehaviour{

	/*		1		 */
		//	Referencia a la camara y al rig
		[Header("Camera Rig")]
		public Transform camera_rig;

		[Space]
		[Header("Camera")]
		public Transform camera_transform;


		[Space]
		[Header("Controllers")]
		public Transform left_controller;
		public Transform right_controller;

		[Space]
		[Header("Virtual world")]
		public Transform virtual_world_reference;
	/*		1		 */

	/*		2		 */
		//	Metodo virtual para crear distintas opciones de alineado.
		public virtual void Align(){

		}
	/*		2		 */

	/*		3		 */
		//	Aplicar la configuracion
		public void WorldSetup(Vector3 position, Quaternion rotation){
			if(virtual_world_reference != null){
				virtual_world_reference.transform.position = position;
				virtual_world_reference.transform.rotation = rotation;
			}
		}
	/*		3		 */

}
