using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class AnimationPopup : MonoBehaviour
{
	private Animator anim;

	private UnityEngine.UI.Text textNotification;
	
	void Start()
	{
		anim = GetComponent<Animator>();
		textNotification = GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>();
	}
	
	public void MoveNotification(string targetName)
	{
		// Detecte si l'anim est en cours
		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("animation_popup"))
		{
			// Défini dynamiquement le contenu de la popup en fonction de l'image target détectée
			switch (targetName)
			{		
				case "winston":
					textNotification.text = "Citoyen, vous venez de rencontrer votre premier camarade du Parti : Winston Smith";
					break;
				case "map":
					textNotification.text = "Citoyen, vous venez de débloquer un nouvel élément de la carte de Londres";
					break;
				default: 
					textNotification.text = "Citoyen, vous venez de débloquer un nouveau contenu";
					break;
			}
			
			// Lance l'animation de la popup
			anim.SetTrigger("Move");
		}
	}
}
