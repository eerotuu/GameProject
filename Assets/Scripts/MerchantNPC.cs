using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MerchantNPC control.
/// </summary>
public class MerchantNPC : MonoBehaviour
{
	//Saves the merchant name.
	public string merchant;
	//Product that merchant sells. Not used currently.
	public string product;
	//Kcal gain for the product
	public int productKcal;
	//Price for the product.
	public int price;


	/// <summary>
	/// Opens talk dialogue for this npc
	/// </summary>
	public void Talk ()
	{
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().MerchantDialogue (this, merchant, product, price, productKcal);
	}

	/// <summary>
	/// Stops the talk.
	/// </summary>
	public void StopTalk ()
	{
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().isActive = false;
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().isLocked = false;
	}
}
