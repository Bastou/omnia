using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float ZoomSpeed;
	public float PanSpeed = 200.0f; 
	public float PanBuffer = 50.0f;

	public float MaxPitch=25f;
	public float MinPitch = -25f;

	private float speed = 1.0F;

	private Plane _Plane;

	// Use this for initialization
	void Start () {
		_Plane = new Plane (Vector3.up, Vector3.zero);
		Vector3 mapCenter = GetCenter(); // 16, 0, 16
		transform.LookAt(mapCenter);
		GameObject Map = GameObject.Find ("MapIso");

	}
	
	// Update is called once per frame
	void Update () {
		HandleZoom ();
		HandlePan ();
	}

	private void HandlePan() {
		
		Vector3 center = GetCenter ();

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Vector2 mousePos = Input.GetTouch (0).deltaPosition;

//			if (mousePos.x < Screen.width / 2) {
//				transform.position -= transform.right * Time.fixedDeltaTime * PanSpeed;
//				Debug.Log ("mousePos.x < PanBuffer");
//			} else if (mousePos.x > Screen.width / 2) {
//				transform.position += transform.right * Time.fixedDeltaTime * PanSpeed;
//				Debug.Log ("mousePos.x > PanBuffer");
//			}
//			if (mousePos.y < PanBuffer) {
//				transform.position -= transform.up * Time.fixedDeltaTime * PanSpeed;
//			} else if (mousePos.y > Screen.height - PanBuffer) {
//				transform.position += transform.up * Time.fixedDeltaTime * PanSpeed;
//			}
			Debug.Log(speed);

			transform.Translate(-mousePos.x * speed, -mousePos.y * speed, 0);

			transform.LookAt (center);


		
//			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
//				// Get movement of the finger since last frame
//				Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
//
//				// Move object across XY plane
//				transform.Translate (-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
//			}
		}
	}

	private void HandleZoom() {
		float scrollValue = Input.mouseScrollDelta.y;

		if (scrollValue != 0.0) {
			
			if (Input.GetKey (KeyCode.LeftControl)) {
				
				Vector3 center = GetCenter ();
				Vector3 dToCenter = transform.position - center;
				Vector3 angles = new Vector3 (0, scrollValue, 0);
				Quaternion newRot = Quaternion.Euler (angles);
				Vector3 dNew = newRot * dToCenter; 
				transform.position = center + dNew;
				transform.LookAt (center);
				//transform.forward = dNew;

			} else {
				
				float newSize = Camera.main.orthographicSize - scrollValue; 
				Camera.main.orthographicSize = Mathf.Clamp(newSize, 3.0f, 20.0f);

			}
		}
		
	}

	private Vector3 GetCenter() {
		Ray ray = new Ray (transform.position, transform.forward); 

		float distance = 0.0f;

		if (_Plane.Raycast (ray, out distance)) {
			return ray.GetPoint (distance);
		}
			
		return Vector3.zero;
	}
}
