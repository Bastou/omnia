using System;
using UnityEngine;
using UnityEngine.UI;

public class SumUpDisplay: MonoBehaviour
{
	public SumUp sumUp;

	public int id;
	public Text nameText;
	public Text contentText;
	public bool unlocked;

	void Start () {
		sumUp.Print();
		nameText.text = sumUp.name;   
		Debug.Log (id + ": " + nameText.text);
	}
}



