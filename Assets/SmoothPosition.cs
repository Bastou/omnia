using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothPosition : MonoBehaviour {

	public Vector3 destination;
	public float speed = 0.1f;

	void Start () {
		Debug.Log ("test");
		destination = transform.position;
	}

	void Update () {
		transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
	}
}