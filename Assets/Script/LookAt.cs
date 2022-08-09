using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookAt : MonoBehaviour{
	public Transform target;
	public bool only_y_axis = true;
	public bool is_ui = false;

	void Start(){
		if(target == null)	target = Camera.main!=null?Camera.main.transform:null;
		if(target == null)	this.enabled = false;
	}

	void Update(){
		if(target == null)	target = Camera.main!=null?Camera.main.transform:null;
		if(target == null)	return;

		if(is_ui){
			Vector3 lookPos = (transform.position - target.position);
			if(only_y_axis){
				lookPos.y = 0f;
			}
			var rotation = Quaternion.LookRotation(lookPos);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 8f);
		}else{
			if(only_y_axis){
				var lookPos = target.position - transform.position;
				lookPos.y = 0;
				var rotation = Quaternion.LookRotation(lookPos);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 8f);
			}else{
				this.transform.LookAt(target);
			}
		}
	}
}
