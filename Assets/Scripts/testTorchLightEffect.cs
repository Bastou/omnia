using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class testTorchLightEffect : MonoBehaviour, ITrackableEventHandler {

	private GameObject arCamera;
	private TrackableBehaviour mTrackableBehaviour;
	private float distance;
	private Renderer renderer;
	private Material mat;
	private bool isTrackableActive;
	private bool mFlashEnabled = false;

	// Use this for initialization
	void Start ()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
		
		renderer = GameObject.Find("Plane").GetComponentInChildren<Renderer>();
		arCamera = GameObject.Find("ARCamera");
		distance = 0.0f;

		mat = renderer.sharedMaterial;

		isTrackableActive = false;
		

	}
	
	// Update is called once per frame
	void Update () {
		

		if (isTrackableActive == true)
		{
			Vector3 delta = Camera.main.transform.position - mTrackableBehaviour.transform.position;

			distance = delta.magnitude;
			float radius = distance / 100.0f;
			mat.SetFloat("_Radius", radius);
		}
	}
	
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) 
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) 
		{
			OnTrackingFound();
			
		}
		else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND)
		{
			OnTrackingLost();
		}
		
		if (!mFlashEnabled)
		{
			// Turn on flash if it is currently disabled.
			CameraDevice.Instance.SetFlashTorchMode(true);
			mFlashEnabled = true;
			Debug.Log(CameraDevice.Instance);
		}
		else
		{
			// Turn off flash if it is currently enabled.
			CameraDevice.Instance.SetFlashTorchMode(false);
			mFlashEnabled = false;
		}
	}


	private void OnTrackingFound()
	{
		isTrackableActive = true;
		
	}

	private void OnTrackingLost()
	{
		isTrackableActive = false;
	}
}
