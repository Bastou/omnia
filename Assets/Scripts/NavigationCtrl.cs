using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NavigationCtrl : MonoBehaviour {

	private MenuCtrl menuCtrl;

	// Use this for initialization
	void Start () {
		// Get objects
		menuCtrl = FindObjectOfType<MenuCtrl> ();
		//gameControl = FindObjectOfType<GameControl> ();
		CtrlBtnNavState("btnMap", "isMapUnlocked");
		CtrlBtnNavState("btnPerso", "isPersoUnlocked");
		
		// TODO: ad when we can scan journal
		//CtrlBtnNavState("btnJournal", "isJournalUnlocked");

	}

	public void BtnClickLoadScene(string sceneName) {
		print(EventSystem.current.currentSelectedGameObject.name);
		menuCtrl.LoadScene(sceneName);
	}

	public void CtrlBtnNavState(string btnName, string unlockParamName)
	{
		if (GameObject.Find(btnName)) // TODO: still usefull
		{
			bool isUnlocked = GameControl.control.GetControlParam(unlockParamName);
			Button btn = GameObject.Find(btnName).GetComponent<Button>();
			RawImage btnIcon = btn.gameObject.transform.GetChild(0).gameObject.GetComponent<RawImage>();
			// Set unlock
			btn.interactable = isUnlocked;
			
			// Set alpha
			Color currColor = btnIcon.color;
			if (isUnlocked)
			{
				currColor.a = 1f;
			}
			else
			{
				currColor.a = 0.4f;
			}
			btnIcon.color = currColor;
		}
	}

}
