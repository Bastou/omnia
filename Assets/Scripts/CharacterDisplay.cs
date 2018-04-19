using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay: MonoBehaviour
{
	public Character character;

	public int id;
	public Text nameText;
	public Text ageText;
	public Image image;
	public Text occupation;
	public Relations[] relations;
	public Text mood;
	public Text description;
	public bool unlocked;

	void Start () {
		character.Print();
		nameText.text = character.name;   
		Debug.Log (id + ": " + nameText.text);
	}
}



