using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*		1		 */
	//	Los tipos de eventos que tendremos en los mandos
	[System.Serializable]	public class XRTouchEvent : UnityEvent<Vector2>{}
	[System.Serializable]	public class XRAxisEvent : UnityEvent<float>{}
	[System.Serializable]	public class XRButtonEvent : UnityEvent{}
/*		1		 */

[System.Serializable]
public class XRInputEvents {
	/*		2		 */
		//	Eventos por tipos
		[Space]
		[Header("Thumbstick")]
		public const float thumbstick_threshold = 0.8f;
		public bool thumbstick_continuous = false;
		public XRTouchEvent on_thumbstick_pressed;
		public XRButtonEvent on_thumbstick_released;
		public XRTouchEvent on_thumbstick_hold;

		[Space]
		[Header("Trigger")]
		public XRAxisEvent on_trigger_pressed;
		public XRButtonEvent on_trigger_released;
		public XRAxisEvent on_trigger_hold;


		[Space]
		[Header("Grip")]
		public XRButtonEvent on_grip_pressed;
		public XRButtonEvent on_grip_released;
		public XRButtonEvent on_grip_hold;

		[Space]
		[Header("Menu")]
		public XRButtonEvent on_menu_pressed;
		public XRButtonEvent on_menu_released;
		public XRButtonEvent on_menu_hold;
	/*		2		 */

	[Space]
	[Header("Debug")]
	public bool debug = true;

	/*		3		 */
		//	almacenaremos cada boton en una variable
		//	INTERNAL
			bool touchpad = false;
			bool trigger = false;
			bool grip = false;
			bool menu = false;
		//	INTERNAL
	/*		3		 */

	/*		8		 */
		public bool IsGrip{
			get => grip;
		}
	/*		8		 */


	//	Funciones
		/*		4		 */
			//	Comprobaciones del touchpad
			public void CheckThumbnail(bool primary){

				OVRInput.Axis2D mask = primary?OVRInput.Axis2D.PrimaryThumbstick:OVRInput.Axis2D.SecondaryThumbstick;
				OVRInput.Button controller_mask = primary?OVRInput.Button.PrimaryThumbstick:OVRInput.Button.SecondaryThumbstick;

				if(thumbstick_continuous){
					if(OVRInput.GetDown( controller_mask ) ){
						touchpad = true;

						on_thumbstick_pressed?.Invoke( OVRInput.Get( mask ) );
						if(debug){
							Debug.Log("Thumbstick touched at: " + OVRInput.Get( mask).ToString() );
						}
					}else if( OVRInput.GetUp( controller_mask ) && touchpad){
						touchpad = false;
						on_thumbstick_released?.Invoke();
						if(debug){
							Debug.Log("Thumbstick released");
						}
					}else if( OVRInput.Get( controller_mask ) && touchpad){
						on_thumbstick_hold?.Invoke( OVRInput.Get( mask ) );
						if(debug){
							Debug.Log("Thumbstick hold at: " + OVRInput.Get( mask).ToString() );
						}
					}
				}else{
					if( OVRInput.Get( mask ).magnitude > thumbstick_threshold ){
						on_thumbstick_hold?.Invoke( OVRInput.Get( mask ) );
					}
				}

			}
		/*		4		 */

		/*		5		 */
			//	Comprobaciones del trigger
			public void CheckTrigger(bool primary){

				OVRInput.Axis1D mask = primary?OVRInput.Axis1D.PrimaryIndexTrigger:OVRInput.Axis1D.SecondaryIndexTrigger;
				OVRInput.Button controller_mask = primary?OVRInput.Button.PrimaryIndexTrigger:OVRInput.Button.SecondaryIndexTrigger;

				//	Primero comprobamos si estamos presionando el trigger
				if( OVRInput.GetDown( controller_mask ) ){

					trigger = true;

					//	Comprobamos cuanto lo estamos pulsando
					on_trigger_pressed?.Invoke( OVRInput.Get( mask ) );
					if(debug){
						Debug.Log("Trigger pressed at: " + ( OVRInput.Get( mask ) ).ToString() );
					}
				}else if( OVRInput.GetUp( controller_mask ) && trigger){
					trigger = false;
					on_trigger_released?.Invoke();
					if(debug){
						Debug.Log("Trigger released");
					}
				}else if( OVRInput.Get( controller_mask )  && trigger){
					on_trigger_hold?.Invoke( OVRInput.Get( mask ) );
					if(debug){
						Debug.Log("Trigger being pressed");
					}
				}
			}
		/*		5		 */

		/*		6		 */
			//	Comprobaciones del grip
			public void CheckGrip(bool primary){

				OVRInput.Axis1D mask = primary?OVRInput.Axis1D.PrimaryHandTrigger:OVRInput.Axis1D.SecondaryHandTrigger;
				OVRInput.Button controller_mask = primary?OVRInput.Button.PrimaryHandTrigger:OVRInput.Button.SecondaryHandTrigger;

				//	comprobamos si estamos presionando el grip
				if( OVRInput.GetDown( controller_mask ) ){
					grip = true;

					on_grip_pressed?.Invoke( );
					if(debug){
						Debug.Log("Grip pressed" );
					}
				}else if( OVRInput.GetUp( controller_mask ) && grip){
					grip = false;
					on_grip_released?.Invoke();
					if(debug){
						Debug.Log("Grip released");
					}
				}else if( OVRInput.Get( controller_mask ) && grip){
					on_grip_hold?.Invoke( );
					if(debug){
						Debug.Log("Grip being pressed");
					}
				}

			}
		/*		6		 */

		/*		7		 */
			//	Comprobaciones del menu
			public void CheckMenu(bool primary){

				OVRInput.Button controller_mask = primary?OVRInput.Button.Start:OVRInput.Button.Start;

				//	comprobamos si estamos presionando el menu
				if( OVRInput.GetDown( controller_mask ) ){
					on_menu_pressed?.Invoke();
					if(debug){
						Debug.Log("Menu pressed" );
					}
				}else if( OVRInput.GetUp( controller_mask ) && menu){
					menu = false;
					on_menu_released?.Invoke();
					if(debug){
						Debug.Log("Menu released");
					}
				}else if( OVRInput.Get( controller_mask ) && menu){
					on_menu_hold?.Invoke( );
					if(debug){
						Debug.Log("Menu being pressed");
					}
				}
			}
		/*		7		 */

	//	Funciones
}
