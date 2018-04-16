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
		Debug.Log(anim.GetCurrentAnimatorStateInfo(0).IsName("animation_popup"));
		//Debug.Log(anim.GetCurrentAnimatorStateInfo(0).IsName("Initial_state"));
		//Debug.Log(anim.GetCurrentAnimatorClipInfo(0));
			
		
		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("animation_popup")) {
			anim.SetTrigger("Move");
		}	
	}
}
