using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CallBackImageDetected : MonoBehaviour, ITrackableEventHandler {
	private TrackableBehaviour mTrackableBehaviour;
	public Transform myModelPrefab;

//	public float minimum = 10.0F;
//	public float maximum = 600.0F;
	public float duration = 1F;
	public bool isWinstoneDetected = false;
	public bool isNotificationHidden = true;
	private float startTime;
//	public float positionXImage = myNotification.transform.position.x;
//	public float positionYImage = myNotification.transform.position.y;

	public float positionXImage;
	public float positionYImage;

	public float increment = 0.0F;

	// Use this for initialization
	void Start () {
		Debug.Log("Init CallBackImageDetection");
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();

		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

		updatePositionNotification ();
	}

	private void updatePositionNotification () {
		UnityEngine.UI.Image myNotification = GameObject.Find("popup").GetComponent<UnityEngine.UI.Image>();
		myNotification.color = UnityEngine.Color.white;

		positionXImage = myNotification.transform.position.x;
		positionYImage = myNotification.transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		if (isWinstoneDetected == true) {

			UnityEngine.UI.Image myNotification = GameObject.Find ("popup").GetComponent<UnityEngine.UI.Image> ();

			if (isNotificationHidden == true) {
				increment += 0.1F;
				float t = (increment - startTime) / (duration / 6);
				myNotification.transform.position = new Vector3 (positionXImage, Mathf.Lerp (positionYImage, positionYImage - 200, t), 0);
			} else {
				increment += 0.1F;
				float t = (increment - startTime) / (duration / 6);
				myNotification.transform.position = new Vector3 (positionXImage, Mathf.Lerp (positionYImage, positionYImage + 200, t), 0);
			}
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

		updatePositionNotification ();
		increment = 0.0F;
		isWinstoneDetected = true;
		isNotificationHidden = true;

		GameControl.control.isMapUnlocked = true;
		GameControl.control.Save ();
		Debug.Log (GameControl.control.isMapUnlocked);
	}

	IEnumerator hideNotification() {
		yield return new WaitForSeconds(4);
		updatePositionNotification ();
		increment = 0.0F;
		isNotificationHidden = false;
	}

	private void onTrackingLost() {
		Debug.Log("Trackable lost");
		StartCoroutine(hideNotification());
	}
}
