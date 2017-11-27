using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveNPC : MonoBehaviour
{

	public bool talks;

	DialogueManager dManager;

	public Npc FastFoodJoe;
	public Npc DoctorDick;


	// Use this for initialization
	void Start ()
	{
		dManager = GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ();
		FastFoodJoe = new Npc ("Fast Food Joe", "Hi! Welcome to Fast Food Joe's Crib.\nWould you like to buy a CheeseBurger for 10$?", true, false);
		DoctorDick = new Npc ("Doctor Dick", "Hi! You have cancer.", false, false);
	}

	public void Talk (Npc npc)
	{
		if (!dManager.isActive && !dManager.isLocked) {
			//dManager.Dialogue (name, message, hasQuestion, sells);
			dManager.Dialogue (npc.name, npc.message, npc.hasQuestion, npc.sells);
		}

	}

	public void StopTalk ()
	{
		dManager.isActive = false;
		dManager.isLocked = false;
	}
}
