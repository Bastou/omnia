using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class AnimationPopup : MonoBehaviour
{
	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}
	
	// Set la trigger "Move" dans l'animation controller
	public void MoveNotification()
	{
		// Detecte si l'anim est en cours
		Debug.Log("isAnimation running : " + this.anim.GetCurrentAnimatorStateInfo(0).IsName("animation_popup"));
			
		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("animation_popup"))
		{
			Debug.Log("Start Move animation");
			anim.SetTrigger("Move");
		}
		else
		{
			anim.ResetTrigger("Move");
		}

		if (anim.IsInTransition(0))
		{
			Debug.Log("Animation is running");
		}
	}
}
