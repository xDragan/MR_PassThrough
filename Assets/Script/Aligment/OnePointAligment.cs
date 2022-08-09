using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePointAligment : BaseAligment{

	public override void Align(){

		/*		1		 */
			// usamos la posicion de la camara
			Vector3 world_position = new Vector3( camera_transform.position.x, camera_rig.position.y, camera_transform.position.z  );

			// usamos también la orientación
			Vector3 world_euler_rotation = camera_transform.rotation.eulerAngles;

			//	solamente queremos la rotación en el eje Y
			world_euler_rotation.x = 0f;
			world_euler_rotation.z = 0f;

			//	Convertimos a un quaternion
			Quaternion world_rotation = Quaternion.Euler(world_euler_rotation);

			//	Aplicamos
			WorldSetup( world_position, world_rotation);
		/*		1		 */
	}
}
