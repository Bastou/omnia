using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CallBackImageDetected : MonoBehaviour, ITrackableEventHandler {
	
	private TrackableBehaviour mTrackableBehaviour;
	public AnimationPopup AnimationPopupScript;
	private ScanSoundNotifs ScanSoundNotifs;

	// Use this for initialization
	void Start ()
	{
		ScanSoundNotifs = GetComponent<ScanSoundNotifs>();
		Debug.Log(ScanSoundNotifs);
		
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();

		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	// Appel OnTrackingFound quand une image target est détectée et OnTrackingLost quand l'image target est perdue
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) 
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) 
		{
			OnTrackingFound();
		}
		else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND)
		{
			onTrackingLost ();
		}
	}

	
	private void OnTrackingFound() 
	{
		
		// Gère toutes les images target
		switch (mTrackableBehaviour.TrackableName)
		{
			case "winston":
				AnimationPopup(targetName:mTrackableBehaviour.TrackableName);
				break;
			
			case "map":
				AnimationPopup(targetName:mTrackableBehaviour.TrackableName);
				UnlockMap();
				break;
			
			case "son1":
				AnimationPopup(targetName:mTrackableBehaviour.TrackableName);
				if(ScanSoundNotifs)
				 ScanSoundNotifs.ToggleSoundNotif();
				break;
			
			default:
				print("Didn't find specific image target");
				break;
		}		 
	}
	
	private void onTrackingLost() 
	{
	}

	private void UnlockMap() 
	{
		// Déblocage de la map et sauvegarde des données
		GameControl.control.isMapUnlocked = true;
		GameControl.control.Save ();
	}

	private void AnimationPopup(string targetName) 
	{
		// Apparition de la Popup
		AnimationPopupScript.MoveNotification(targetName);
	}
}
