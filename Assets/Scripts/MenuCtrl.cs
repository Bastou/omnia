using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour {

	UnityEngine.UI.Button button;

	void Start() {

		// # Find btn map and set active if map is unlocked
//		button = GameObject.Find("btnMap").GetComponent<UnityEngine.UI.Button>();
//		Debug.Log ("isMapUnlocked = " + GameControl.control.isMapUnlocked);
//		if (GameControl.control.isMapUnlocked == true) {
//			button.gameObject.SetActive (true);
//		} else {
//			button.gameObject.SetActive (false);
//		}
	}

	// SceneLoader
 	public void LoadScene(string sceneName) {
		StartCoroutine(StartScene(sceneName));
	}

	IEnumerator StartScene(string sceneName) {
		float fadeTime = GetComponent<Fading> ().BeginFade (1); // 1 cause fade out
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene (sceneName);	 		
 	}	 	

}
