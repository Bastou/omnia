using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class takePhoto : MonoBehaviour {

	WebCamTexture webCamTexture;

	void Start () 
	{
		WebCamDevice[] devices = WebCamTexture.devices;
		foreach (WebCamDevice cam in devices) {
			if (cam.isFrontFacing) {
				webCamTexture = new WebCamTexture ();
				webCamTexture.deviceName = cam.name;
				webCamTexture.Play ();
			}
		}
	}

	public void snapshot() 
	{
		Texture2D photo = new Texture2D (webCamTexture.width, webCamTexture.height);
		photo.SetPixels (webCamTexture.GetPixels ());
		photo.Apply ();

		byte[] bytes = photo.EncodeToPNG ();
		File.WriteAllBytes (Application.persistentDataPath + "photo.png", bytes);
		Debug.Log (Application.persistentDataPath);
	}
}
