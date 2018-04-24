using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture;
	private float fadeTime = 0.1f; 
	private float fadeSpeed = 10f;

	private int drawDepth = -1000; 	
	private float alpha = 1.0f;
	private int fadeDir = -1;

	// Unity function to render GUI
	void OnGUI() {
		// fadet in/out alpha using direction; speed and time;
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		// force (clamp) the number between 0 and 1 cause GUI.color is bt 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		// set color of our GUI (in this case our texture). All color values remain the same & Alpha is set to alpha var
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha); // Set alpha
		GUI.depth = drawDepth; // Makesure black texture is on top
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture); // Draw texture to fit the entire screen

	}

	// set fadeDir to the direction parm making the scene fade in if -1 and out if 1
	public float BeginFade(int direction) {
		fadeDir = direction;
		return (fadeTime); // return the fadeSpeed var so it's easy to time the Application.LoadLevel();
	}

	// OnLevelWasLoaded  is called when a level is loaded. It takes loaded level index (int) as parameter so you can limit the fade in certain scenes
	void OnLevelWasLoaded() {
		// alpha = 1 // use this if alpha is not set to 1 by default
		BeginFade (-1); // call the fade in function
		Debug.Log ("init fade in with speed = "  + fadeTime);
	}
}
