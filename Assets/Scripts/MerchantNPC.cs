using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantNPC : MonoBehaviour
{

	public string merchant;
	public string product;
	public int productKcal;
	public int price;
	

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Talk ()
	{
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().MerchantDialogue (this, merchant, product, price, productKcal);
	}

	public void StopTalk ()
	{
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().isActive = false;
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().isLocked = false;
	}
}
