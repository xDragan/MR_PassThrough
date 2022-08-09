using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointsRigAligment : BaseAligment{

	public override void Align(){

		/*		1		 */
			//	en este caso la posicion sera el punto medio entre los dos controladores.
			Vector3 world_position = right_controller.position + (left_controller.position - right_controller.position) * 0.5f;

			//	Ajustamos la altura al suelo 
			world_position.y = camera_rig.position.y;

			//	la rotación la sacaremos a partir de un vector de dirección
			Vector3 controllers_direction = right_controller.position - left_controller.position;
			Vector3 world_direction = Quaternion.AngleAxis(-90, Vector3.up) * controllers_direction.normalized;
			world_direction.y = 0f;

			//	Convertimos la dirección a una rotación 
			Quaternion world_rotation = Quaternion.LookRotation(world_direction);

			WorldSetup( world_position, world_rotation);
		/*		1		 */
	}
}
