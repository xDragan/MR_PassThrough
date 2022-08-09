using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointsAligment : BaseAligment{

	public override void Align(){

		/*		1		 */
			//	en este caso la posicion sera el punto medio entre los dos controladores.
			Vector3 world_position = right_controller.position + (left_controller.position - right_controller.position) * 0.5f;

			//	la rotación la sacaremos a partir de un vector de dirección
			Vector3 controllers_direction = right_controller.position - left_controller.position;

			//	Lo giramos 90º
			Vector3 world_direction = Quaternion.AngleAxis(-90, Vector3.up) * controllers_direction.normalized;

			//	Dejamos solamente la rotación en el eje Y
			world_direction.y = 0f;

			//	Convertimos la dirección a una rotación 
			Quaternion world_rotation = Quaternion.LookRotation(world_direction);

			//	Aplicamos el setup
			WorldSetup( world_position, world_rotation);
		/*		1		 */
	}
}
