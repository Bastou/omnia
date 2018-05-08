using System;
using UnityEngine;
using UnityEngine.UI;

public class PlaceDisplay: MonoBehaviour
{
	public Place place;

	public int id;
	public Text nameText;
	public Text descriptionText;
	public bool unlocked;

	void Start () {
		place.Print();
		nameText.text = place.name;   
		Debug.Log (id + ": " + nameText.text);
	}
}



