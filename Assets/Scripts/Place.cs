using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Place", menuName = "Place")]
public class Place : ScriptableObject
{
	public int id;
	public InfosPlace infos;

	public void Print () {
		Debug.Log (id + ": " + infos + " Infos" + infos.states[0].name);
	}
}

[Serializable]
public class InfosPlace
{
	public StatePlace[] states;
}

[Serializable]
public class StatePlace
{
	public int id;
	public string name;
	public string description;
	public bool unlocked;
}