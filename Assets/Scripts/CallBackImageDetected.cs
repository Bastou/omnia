using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CallBackImageDetected : MonoBehaviour, ITrackableEventHandler {
	private TrackableBehaviour mTrackableBehaviour;

	public AnimationPopup AnimationPopupScript;

	// Use this for initialization
	void Start () {
		Debug.Log("Init CallBackImageDetection");
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();

		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			OnTrackingFound();
		}
		else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND) {
			onTrackingLost ();
		}
	}

	private void OnTrackingFound() {
		Debug.Log ("Tracking found");
		
		// Déblocage de la map
		GameControl.control.isMapUnlocked = true;
		GameControl.control.Save ();
		
		// Apparition de la Popup
		AnimationPopupScript.MoveNotification();		 
	}

	private void onTrackingLost() {
		Debug.Log("Trackable lost");
	}
}
