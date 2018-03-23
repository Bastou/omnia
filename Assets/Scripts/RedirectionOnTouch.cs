using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RedirectionOnTouch : MonoBehaviour, IPointerClickHandler {
	
	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData) {
		Debug.Log("Touched");
		SceneManager.LoadScene ("FichePerso");

	}
	#endregion


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
