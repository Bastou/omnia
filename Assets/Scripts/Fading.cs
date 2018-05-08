using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour {

	//public Texture2D fadeOutTexture;
	private float fadeTime = 0.2f; 
	private float fadeSpeed = 5f;

	private int drawDepth = -1000; 	
	private float alpha = 1.0f;
	private int fadeDir = -1;
	
	private static bool loadingScreenCreated;

	private GameObject loadingScreen;
	private GameObject UILoader;

	private int i = 0;
	
	void Start()
	{
		UILoader = GameObject.Find("UILoader");
		
		loadingScreen = Instantiate(Resources.Load("LoadingScreen")) as GameObject;
		if (loadingScreen != null) loadingScreen.transform.SetParent(UILoader.transform, false);

		if (!loadingScreenCreated)
		{
			DontDestroyOnLoad(UILoader);
			loadingScreenCreated = true;
			Debug.Log("Awake: " + UILoader.name);	
		}
	}
	
	void _Start() {
		//loadingScreen = Instantiate(Resources.Load("LoadingScreen")) as GameObject; 
		//loadingScreen.transform.SetParent (GameObject.Find("LoadingUI").transform, false);
		//print(loadingScreen);
	}

	// Unity function to render GUI
	void OnGUI()
	{
		if (!(alpha > 0)) return; 
		print("Ongui called " + i);
		i++;
		
		// Return if alpha already egals to 0 to keep perf
		if (!(alpha >= 0)) return;
		
		// fadet in/out alpha using direction; speed and time;
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		// force (clamp) the number between 0 and 1 cause GUI.color is bt 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		// WITH TEXTURE
		// set color of our GUI (in this case our texture). All color values remain the same & Alpha is set to alpha var
		//GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha); // Set alpha
		//GUI.depth = drawDepth; // Makesure black texture is on top
		//GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture); // Draw texture to fit the entire screen

		// OR //

		// WITH LOAD SCREEN
		//Debug.Log(alpha);
		if(loadingScreen) {
			loadingScreen.GetComponent<CanvasGroup>().alpha = alpha;
			// Fade out
			if (fadeDir == 1) {
				loadingScreen.SetActive (true);
				print("loading screen show");
			}

			// fade in
			if (fadeDir == -1) {
				loadingScreen.SetActive (false);
				print("loading screen hide");
			}	
		}
		
	}

	// set fadeDir to the direction parm making the scene fade in if -1 and out if 1
	public float BeginFade(int direction) {
		fadeDir = direction;
		return (fadeTime); // return the fadeSpeed var so it's easy to time the Application.LoadLevel();
	}

	// OnLevelWasLoaded  is called when a level is loaded. It takes loaded level index (int) as parameter so you can limit the fade in certain scenes
	void OnLevelWasLoaded()
	{
		alpha = 1; // use this if alpha is not set to 1 by default
		BeginFade (-1); // call the fade in function
		Debug.Log ("init fade in with speed = "  + fadeTime);
	}
}
