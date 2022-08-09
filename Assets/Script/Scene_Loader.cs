using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Loader : MonoBehaviour {

	public void Load (string scene_name) {
		SceneManager.LoadScene(scene_name);
	}
	public void Load (int scene_index) {
		SceneManager.LoadScene(scene_index);
	}
}
