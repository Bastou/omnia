using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationCtrl : MonoBehaviour {

	private MenuCtrl menuCtrl;

	// Use this for initialization
	void Start () {
		menuCtrl = FindObjectOfType<MenuCtrl> ();
	}

	public void BtnClickLoadScene(string sceneName) {
		menuCtrl.LoadScene(sceneName);
	}

}
