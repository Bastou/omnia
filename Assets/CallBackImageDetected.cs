using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CallBackImageDetected : MonoBehaviour, ITrackableEventHandler {
	private TrackableBehaviour mTrackableBehaviour;
	public Transform myModelPrefab;
	public float speed = 5f;

	// Use this for initialization

	UnityEngine.UI.Image myNotification;

	void Start () {
		Debug.Log("Init CallBackImageDetection");
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	// Update is called once per frame
	void Update () {
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

		UnityEngine.UI.Image myNotification = GameObject.Find("popup").GetComponent<UnityEngine.UI.Image>();
		float positionXImage = myNotification.transform.position.x;
		float positionYImage = myNotification.transform.position.y;
		myNotification.transform.position = new Vector3(positionXImage, positionYImage - 150, 0);
		//myNotification.GetComponent<SmoothPosition>().targetPosition = new Vector3(positionXImage, positionYImage - 150, 0);
		//myNotification.GetComponent<SmoothPosition>().destination = new Vector3(positionXImage, positionYImage - 150, 0);
		//Debug.Log(myNotification.GetComponent<SmoothPosition>().destination);
		StartCoroutine(hideNotification());
	}

	IEnumerator hideNotification() {
		UnityEngine.UI.Image myNotification = GameObject.Find("popup").GetComponent<UnityEngine.UI.Image>();
		float positionXImage = myNotification.transform.position.x;
		float positionYImage = myNotification.transform.position.y;
		yield return new WaitForSeconds(4);
		myNotification.transform.position = new Vector3(positionXImage, positionYImage + 150, 0);
	}

	private void onTrackingLost() {
		Debug.Log("Trackable lost");
	}
}
