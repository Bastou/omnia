using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour {

	public void LoadScene(string sceneName) {
		StartCoroutine(StartScene(sceneName));
	}

	// SceneLoader
	IEnumerator StartScene(string sceneName) {
		float fadeTime = GetComponent<Fading> ().BeginFade (1); // 1 cause fade out
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene (sceneName);
	}
	
}
