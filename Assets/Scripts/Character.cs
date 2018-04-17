using System;

[Serializable]
public class Character
{
	public int id;
	public PersoInfos[] infos;

}

[Serializable]
public class PersoInfos
{
	public string state;
	public string name;
	public int age;
	public string occupation;
	public Array relations;
	public string mood;
	public string description;
	public bool unlocked;
}

