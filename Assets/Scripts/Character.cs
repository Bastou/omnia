using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
	public int id;
	public InfosCharacter infos;

	public void Print () {
		Debug.Log (id + ": " + infos + " Infos" + infos.states[0].name);
	}
}

[Serializable]
public class InfosCharacter
{
	public StateCharacter[] states;
}

[Serializable]
public class StateCharacter
{
	public int id;
	public string name;
	public int age;
	public Image image;
	public string occupation;
	public Relations[] relations;
	public string mood;
	public string description;
	public bool unlocked;
}

[Serializable]
public class Relations {
	public int id;
}


