using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Scan", menuName = "Scan")]
public class Scan : ScriptableObject
{
	public int id;
	public string type;
	public bool state;

	public void Print () {
		Debug.Log (id + ": " + " Infos" + type + "State" + state);
	}
}