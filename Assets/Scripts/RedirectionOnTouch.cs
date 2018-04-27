using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RedirectionOnTouch : MonoBehaviour, IPointerClickHandler {
	
	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData)
	{
		//Redirige vers la scène FichePerso au clic/touch
		SceneManager.LoadScene ("FichePerso");
	}
	#endregion
}
