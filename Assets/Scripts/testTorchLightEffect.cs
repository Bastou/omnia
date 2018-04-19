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
	private float multiplier;

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

		multiplier = 1.0f;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (isTrackableActive == true)
		{
			Vector3 delta = Camera.main.transform.position - mTrackableBehaviour.transform.position;
			distance = delta.magnitude;
			
			float radius = distance / 100.0f;
			//float radius = distance / 200.0f;

			if (radius < 0.1f)
			{
				radius = 0.1f;
			}
			mat.SetFloat("_Radius", radius);

			Quaternion rotationCamera = Camera.main.transform.rotation;
			Quaternion target= mTrackableBehaviour.transform.rotation;
			Quaternion rotation = rotationCamera * Quaternion.Inverse(target);
			float rotationX = Mathf.Abs(rotation.x);

			// Mapping de la valeur à passer au shader pour simuler la perspective lorsque
			// le device n'est pas parallèle au livre (mapping nécessaire pour ne pas trop déformer l'halo)
			float _RotationLow = 0.5f;
			float _RotationHigh = 0.9f;;
			float mappedRotationShader = Mathf.Lerp(_RotationLow, _RotationHigh, rotationX);
			
			mat.SetFloat("_Rotation", mappedRotationShader);
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
			//		CameraDevice.Instance.SetFlashTorchMode(true);
			//mFlashEnabled = true;
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
