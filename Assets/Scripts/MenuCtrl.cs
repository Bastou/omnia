using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCtrl : MonoBehaviour {

	// TODO: Dans navigationctrl ->
	private Button btnMap;
	private Button btnPerso;
	private Button btnJournal;
	
	private RawImage iconMap;
	private RawImage iconPerso;
	private RawImage iconJournal;
	private Color _iconMapColor;
	// <-

	private Fading fading;
	public Slider slider;

	void Start()
	{

		// Setup fading
		fading = GetComponent<Fading> ();

		// TODO: Dans navigationctrl ->

//		// # Find btn map and set active if map is unlocked
//		if (btnMap == null && GameObject.Find("btnMap") && GameObject.Find("IconMap"))
//		{
//			btnMap = GameObject.Find("btnMap").GetComponent<Button>();	
//			btnMap.gameObject.SetActive(GameControl.control.isMapUnlocked == true);
//			iconMap = GameObject.Find("IconMap").GetComponent<RawImage>();
//			Color currColor = iconMap.color;
//			if (GameControl.control.isMapUnlocked)
//			{
//				currColor.a = 1f;
//			}
//			else
//			{
//				currColor.a = 0.4f;
//			}
//			iconMap.color = currColor;
//		}

//		iconMap = GameObject.Find("IconMap").GetComponent<RawImage>();
//		Debug.Log(iconMap);
//		_iconMapColor = iconMap.color;
//		_iconMapColor.a = 0f; 


//		// # Find btn perso and set active if perso is unlocked
//		btnPerso = GameObject.Find("btnPerso").GetComponent<Button>();
//		Debug.Log ("isPersoUnlocked = " + GameControl.control.isPersoUnlocked);
//		btnPerso.gameObject.SetActive(GameControl.control.isPersoUnlocked == true);
//		
//		// # Find btn perso and set active if perso is unlocked
//		btnJournal = GameObject.Find("btnJournal").GetComponent<Button>();
//		Debug.Log ("isJournalUnlocked = " + GameControl.control.isJournalUnlocked);
//		btnJournal.gameObject.SetActive(GameControl.control.isJournalUnlocked == true);

		// <-
	}

	void Update()
	{
		//_iconMapColor.a = 0f; 
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
		Debug.Log(slider);
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
