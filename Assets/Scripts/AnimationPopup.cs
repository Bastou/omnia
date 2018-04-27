using System.Collections;
using UnityEngine;

public class AnimationPopup : MonoBehaviour {
	private Animator anim;
	private bool hasScan = false;
	private UnityEngine.UI.Text textNotification;
	
	void Start()
	{
		anim = GetComponent<Animator>();
		textNotification = GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>();
		
		// Lance la notif de rappel de la lecture
		StartCoroutine(NotifGoRead());
	}
	
	public void MoveNotification(string targetName)
	{
		// HasScan state
		hasScan = true;
		
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
				case "hiddenText":
					textNotification.text = "Citoyen, vous venez de débloquer une partie du journal de Winston";
					break;
				default: 
					textNotification.text = "Des nouvelles sur la bande RTF des chiffres du metal";
					break;
			}
			
			// Lance l'animation de la popup
			anim.SetTrigger("Move");
		}
	}
	
	// Notif de rappel de lecture si on ne scan rien
	IEnumerator NotifGoRead()
	{	
		yield return new WaitForSeconds(7);
		print("hasScan : " + hasScan);
		if(hasScan) yield break;
		anim.SetTrigger("Move");
		yield break;
	}
}
