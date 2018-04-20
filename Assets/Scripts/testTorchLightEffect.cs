using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

	private GameObject Plane;

	private Renderer rend;

	private Color[] pix;

	private Texture2D texturePlane;
	private Texture2D myTexture2D;
	
	public Transform target;

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

		Plane = GameObject.Find("Plane");
		
		rend = GetComponent<Renderer>();
		
		texturePlane = Plane.GetComponent<MeshRenderer>().material.GetTexture("_Texture2") as Texture2D;
		myTexture2D = new Texture2D(texturePlane.width, texturePlane.height);

		arCamera = GameObject.Find("/ARCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isTrackableActive == true)
		{
			Vector3 delta = Camera.main.transform.position - mTrackableBehaviour.transform.position;
			distance = delta.magnitude;
			
			//float radius = distance / 100.0f;
			float radius = distance / 200.0f;

			if (radius < 0.1f)
			{
				radius = 0.1f;
			}
			mat.SetFloat("_Radius", radius);

			Quaternion rotationCamera = Camera.main.transform.rotation;
			Quaternion rotationTarget= mTrackableBehaviour.transform.rotation;
			Quaternion rotation = rotationCamera * Quaternion.Inverse(rotationTarget);
			float rotationX = Mathf.Abs(rotation.x);

			// Mapping de la valeur à passer au shader pour simuler la perspective lorsque
			// le device n'est pas parallèle au livre (mapping nécessaire pour ne pas trop déformer l'halo)
			float _RotationLow = 0.5f;
			float _RotationHigh = 0.9f;;
			float mappedRotationShader = Mathf.Lerp(_RotationLow, _RotationHigh, rotationX);
			
			mat.SetFloat("_Rotation", mappedRotationShader);
			
			
			// TODO : Detecter si l'utilisateur à découvert tout le texte 
			
			//Debug.Log(renderer.material.GetTexture("map_scaled"));

			Color[] pixel = myTexture2D.GetPixels(0, 0, texturePlane.width, texturePlane.height);
			//Debug.Log(pixel);

			float positionCamera = Mathf.Abs(Camera.main.transform.position.x);
			float positionTarget = Mathf.Abs(mTrackableBehaviour.transform.position.x);

			float distanceX = Camera.main.transform.position.x - mTrackableBehaviour.transform.position.x;
			float distanceY = Camera.main.transform.position.z - mTrackableBehaviour.transform.position.z;
			
			Debug.Log(distanceX);
			Debug.Log(distanceY);
			Debug.Log("______________");
			
			//12
			//3.5

			float firstRepereX = 12f;
			float firstRepereY = -3.5f;

			bool firstRepereReached = false;
			
			float lasttRepereX = 0.3f;
			float lastRepereY = -21f;

			bool lastRepereReached = false;
			

//			Debug.Log(positionCamera - 1);
//			Debug.Log(positionTarget);
//			Debug.Log("_________________");

			if (distanceX < (firstRepereX + 0.5f) && distanceY < (firstRepereY + 0.5f))
			{
				Debug.Log("first repere reached");
				firstRepereReached = true;
			}

			if (distanceX > (lasttRepereX - 0.5f) && distanceY < (lastRepereY - 0.5f))
			{
				Debug.Log("last repere reached");
				lastRepereReached = true;
			}

			if (firstRepereReached == true && lastRepereReached == true)
			{
				CameraDevice.Instance.SetFlashTorchMode(true);
				mFlashEnabled = true;
				Debug.Log("Hello journal !");
			}			
			

			//Debug.Log("target is " + screenPos.x + " pixels from the left");
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
