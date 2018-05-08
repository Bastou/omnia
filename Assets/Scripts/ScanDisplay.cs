using System;
using UnityEngine;
using UnityEngine.UI;

public class ScanDisplay: MonoBehaviour
{
	public Scan scan;

	public int id;
	public Text typeText;
	public bool state;

	void Start () {
		scan.Print();
		typeText.text = scan.type;   
		Debug.Log (id + ": " + typeText.text);
	}
}



