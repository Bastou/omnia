using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPersistantIncrementer : MonoBehaviour {
	private int i = 0;

	public void Init()
	{
		InvokeRepeating("Incrementby1", 1.0f, 2.0f);
	}

	void Incrementby1()
	{
		i++;
		Debug.Log ("counter = " + i);
	}
}
