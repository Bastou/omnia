using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPopup : MonoBehaviour
{
	private Animator anim;

	// Set la trigger "Move" dans l'animation controller
	public void MoveNotification()
	{
		anim = GetComponent<Animator>();
		anim.SetTrigger("Move");
	}
}
