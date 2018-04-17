using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanSoundNotifs : MonoBehaviour {
    private GameObject popupson;

    // Active images for sound notifs
    public void ToggleSoundNotif(string name = "popupson_note1")
    {
        string basePath = "/UI/popupson/";
        popupson = GameObject.Find(basePath + name);
        Debug.Log(popupson.name);
        popupson.SetActive(!popupson.activeInHierarchy);
    }
}
