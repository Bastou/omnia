using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCtrl : MonoBehaviour {

	private Fading fading;
	private Slider slider;

	void Start()
	{

		// Setup fading
		fading = GetComponent<Fading> ();
		slider = GameObject.Find("Slider").GetComponent<Slider>();
		print(slider);

	}


	// SceneLoader
 	public void LoadScene(string sceneName) {
     		StartCoroutine(StartScene(sceneName));
     }


	// TODO: remove
	public void LoadSceneQuick(string sceneName) {
		SceneManager.LoadScene (sceneName);	 
	}

	IEnumerator StartScene(string sceneName) {
		//button.onClick.AddListener(LoadScene()); -> load scene
		float fadeTime = fading.BeginFade (1); // 1 cause fade out
		yield return new WaitForSeconds(fadeTime);
		//SceneManager.LoadScene (sceneName);	 	
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneName);

		//loadingScreen.SetActive (true);
		//Debug.Log(slider);
		if (slider) {
			while (!operation.isDone) {
				float progress = Mathf.Clamp01 (operation.progress / 0.9f);
				//Debug.Log (progress);
				slider.value = progress;
				yield return null;
			}
		}
 	}	 	

}
