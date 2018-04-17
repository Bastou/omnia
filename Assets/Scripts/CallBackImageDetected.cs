using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using System.IO;

public class CallBackImageDetected : MonoBehaviour, ITrackableEventHandler {
	
	private TrackableBehaviour mTrackableBehaviour;
	public AnimationPopup AnimationPopupScript;
	private string gameDataFileName = "character.json";

	// Use this for initialization
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();

		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	// Appel OnTrackingFound quand une image target est détectée et OnTrackingLost quand l'image target est perdue
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			OnTrackingFound();
		}
		else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND) {
			onTrackingLost ();
		}
	}

	
	private void OnTrackingFound() {
		// Gère toutes les images target
		switch (mTrackableBehaviour.TrackableName)
		{
		case "winston":
			AnimationPopup ();
			deserializeJson ();
			break;
			
			case "map":
				UnlockMap();
				break;
			
			default:
				print("Didn't find specific image target");
				break;
		}		 
	}
	
	private void onTrackingLost() {
	}

	private void UnlockMap() {
		// Déblocage de la map et sauvegarde des données
		GameControl.control.isMapUnlocked = true;
		GameControl.control.Save ();
	}

	private void AnimationPopup() {
		// Apparition de la Popup
		AnimationPopupScript.MoveNotification();
	}

	private void deserializeJson() {

		string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

		if (File.Exists (filePath)) {
			// Read the json from the file into a string
			string dataAsJson = File.ReadAllText (filePath); 
			// Pass the json to JsonUtility, and tell it to create a GameData object from it

			Character[] character = JsonHelper.FromJson<Character>(dataAsJson);
			Debug.Log("name:" + character[0].infos[0].name);
//			foreach(object isxtem in character[0].infos) {
//				Debug.Log("INFOS:" + item);
//			}
		} else {
			Debug.Log ("///// NOPE ///////"); 
		}
	}

	
}
