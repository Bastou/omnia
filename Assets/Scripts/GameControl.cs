using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public bool isMapUnlocked;

	// Créer un singleton GameControl pour la gestion des données persistantes
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this){
			Destroy (gameObject);
		}
	}

	// Label pour voir l'état de la variable "isMapUnlocked"
	void OnGUI(){
		GUI.Label (new Rect (10, 10, 100, 30), "isMapUnlocked: " + isMapUnlocked);
	}

	// Sauvegarde les données
	public void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/data.dat");

		PlayerData data = new PlayerData ();
		data.isMapUnlocked = isMapUnlocked;

		bf.Serialize (file, data);
		file.Close();
	}

	// Charge les données
	public void Load() {
		if (File.Exists (Application.persistentDataPath + "/data.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/data.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file); //Cast to generic object to PlayerData specifically
			file.Close();

			isMapUnlocked = data.isMapUnlocked;
		}
	}
}

// Tell to Unity we can save the data to a file
[Serializable]
class PlayerData {
	public bool isMapUnlocked;
}