using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RedirectionOnTouch : MonoBehaviour, IPointerClickHandler {
	
	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData) {
		Debug.Log("Touched");

	}
	#endregion

	public void LoadByIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
