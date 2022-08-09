using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class XRRaycast : MonoBehaviour {

	/*		1		 */
		[Space]
		[Header("Ray origin")]
		public Transform origin;

		[Space]
		[Header("Distancia maxima del rayo")]
		public float max_distance = 10f;

	/*		1		 */

	/*		2		 */
		//	INTERNAL
			//	El objeto que visualizara rayos
			LineRenderer line_renderer;

			//	estamos apuntado o no
			public bool is_pointing = false;

			//	Donde almacenaremos los hit
			RaycastHit hit;

			XRButton xr_button;
		//	INTERNAL
	/*		2		 */


	void Start () {
		/*		3		 */
			//	Cogemos el line renderer del gameobject
			line_renderer = this.GetComponent<LineRenderer>();

			//	Ajustamos el origen del rayo
			if(origin == null)	origin = this.transform;
		/*		3		 */
	}

	[ContextMenu("Start Pointing")]
	public void StartPointing(){
		/*		4		 */
			//	El mando nos informara que tenemos que apuntar
			is_pointing = true;

			xr_button = null;
		/*		4		 */
	}

	[ContextMenu("Stop Pointing")]
	public void StopPointing(){
		/*		5		 */
			//	El mando nos informara que tenemos que dejar de apuntar
			Vector3 hit_position = CheckRaycast();

			FireCurrent();

			is_pointing = false;
			SetupLine( 0f );
		/*		5		 */
	}

	void FixedUpdate(){
		/*		6		 */
			//	si lo esta actualizamos el rayo
			CheckRaycast();

			if(hit.collider == null){
				DeselectCurrent();
			}else if(hit.collider.gameObject.GetComponent<XRButton>() != null && hit.collider.gameObject.GetComponent<XRButton>() != xr_button){
				SelectObject(hit.collider.gameObject.GetComponent<XRButton>());
			}
		/*		6		 */
	}

	#region funciones_ray
		/*		8		 */
		public void SetupLine(float distance){
			//	El rayo comenzara en el objeto fijado de origen y terminara en la distancia marcada en la direccion de este objeto
			line_renderer.SetPosition(0, origin.position);
			line_renderer.SetPosition(1, origin.position + (this.transform.TransformDirection(Vector3.forward) * distance) );

			#if UNITY_EDITOR
				Debug.DrawLine(origin.position, (origin.position + (this.transform.TransformDirection(Vector3.forward) * distance)) );
			#endif
		}
		/*		8		 */

		/*		7		 */
			public Vector3 CheckRaycast(){
				//	direccion frontal desde este objeto
				Vector3 forward = this.transform.TransformDirection(Vector3.forward);

				//	Tiramos el rayo y vemos si choca y contra que
				if (Physics.Raycast(origin.position, forward, out hit, max_distance)){

					//	Comprobamos si el objeto permite teletransportarse
					if(hit.collider.gameObject.GetComponent<XRButton>() != null ){
						SetupLine( hit.distance );
						return hit.point;
					}else{
						SetupLine( 0f );
					}
				}else{
					SetupLine( 0f );
				}
				return Vector3.zero;
			}
		/*		7		 */
	#endregion

	#region funciones_seleccion
		/*		9		 */
			void SelectObject(XRButton _xrb){
				DeselectCurrent();
				xr_button = _xrb;
				xr_button.OnSelect(this.gameObject);
			}
			void DeselectCurrent(){
				if(xr_button != null){
					xr_button.OnDeselect(this.gameObject);
					xr_button = null;
				}
			}

			void FireCurrent(){
				if(xr_button != null)	xr_button.FireEvent(this.gameObject);
				// xr_button = null;	//	por diseño
			}
		/*		9		 */
	#endregion	// funciones_seleccion

}
