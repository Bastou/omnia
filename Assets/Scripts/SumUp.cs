using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Sum up", menuName = "Sum up")]
public class SumUp : ScriptableObject
{
	public int id;
	public InfosSumUp infos;

	public void Print () {
		Debug.Log (id + ": " + infos + " Infos" + infos.states[0].name);
	}
}

[Serializable]
public class InfosSumUp
{
	public StateSumUp[] states;
}

[Serializable]
public class StateSumUp
{
	public int id;
	public string name;
	public string content;
	public bool unlocked;
}