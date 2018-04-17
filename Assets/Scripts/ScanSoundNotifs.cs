using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanSoundNotifs : MonoBehaviour {
    private GameObject popupson;
	private string basePath = "/UI/popupson/";
	private GameObject container;

    // Active images for sound notifs
    public void ToggleSoundNotif(string name = "popupson_note1")
    {

		container = GameObject.Find("/UI/popupson/");
		Debug.Log (GameObject.Find("/UI/popupson/"));
		//container.SetActive (true);
        popupson = GameObject.Find(basePath + name);
        popupson.SetActive(!popupson.activeInHierarchy);
    }
}
