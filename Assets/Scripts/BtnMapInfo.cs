using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnMapInfo : MonoBehaviour, IPointerClickHandler
{

	private GameObject infoPanel;
	private GameObject button;

	private void Start()
	{
		infoPanel = GameObject.Find("InfoPanel");
		ToggleInfoPanel();
	} 

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log(gameObject.name + " Was Clicked.");
		ToggleInfoPanel();
	}
	
	
	private void ToggleInfoPanel ()
	{
		Debug.Log("In ToggleInfoPanel");
		//infoPanel = GameObject.Find("InfoPanel");
		infoPanel.SetActive(!infoPanel.activeSelf);
	}
}
