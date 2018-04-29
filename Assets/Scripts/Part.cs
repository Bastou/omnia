using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Part", menuName = "Part")]
public class Part : ScriptableObject
{
	public int id;
	public InfosPart infos;

	public void Print () {
		Debug.Log (id + ": " + infos + " Infos" + infos.states[0].name);
	}
}

[Serializable]
public class InfosPart
{
	public StatePart[] states;
}

[Serializable]
public class StatePart
{
	public int id;
	public string name;
	public string content;
	public bool unlocked;
}