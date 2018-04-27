using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPopup : MonoBehaviour {
	private Animator anim;

	void Start() {
		anim = GetComponent<Animator>();
	}
	
	// Set la trigger "Move" dans l'animation controller
	public void MoveNotification()
	{				
		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("animation_popup")) {
			anim.SetTrigger("Move");
		}	
	}
}
