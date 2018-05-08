using System;
using UnityEngine;
using UnityEngine.UI;

public class PartDisplay: MonoBehaviour
{
	public Part part;

	public int id;
	public Text nameText;
	public Text contentText;
	public bool unlocked;

	void Start () {
		part.Print();
		nameText.text = part.name;   
		Debug.Log (id + ": " + nameText.text);
	}
}



