﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveNPC : MonoBehaviour
{

	public bool talks;

	DialogueManager dManager;

	public Npc FastFoodJoe;
	public Npc DoctorDick;
	public Npc DoctorNick;
	public Npc NurseNancy;


	// Use this for initialization
	void Start ()
	{
		dManager = GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ();
		FastFoodJoe = new Npc ("Fast Food Joe", "Hi! Welcome to Fast Food Joe's Crib.\nWould you like to buy a CheeseBurger for 10$?", true, false);
		DoctorDick = new Npc ("Doctor Dick", "So... Bobby Ulk. I'm worried about your bulking habit. I need you to start healthy diet and stop this fast food madness.\n\nAre you OK with this?", false, true);
		DoctorNick = new Npc ("Doctor Nick", "hulabaloba.", false, true);
		NurseNancy = new Npc ("Nurse Nancy", "Hi!\nAre you here for your meds?", false, true);
	}

	public void Talk (Npc npc, InteractiveNPC iNpc)
	{
		if (!dManager.isLocked) {
			//dManager.Dialogue (name, message, hasQuestion, sells);
			dManager.Dialogue (iNpc, npc, npc.name, npc.message, npc.hasQuestion, npc.sells);
		}

	}

	public void StopTalk ()
	{
		dManager.isActive = false;
		dManager.isLocked = false;
	}

	public void ChangeDialogueStatus (Npc npc, string message, bool hasQuestion, bool sells)
	{
		npc.message = message;
		npc.hasQuestion = hasQuestion;
		npc.sells = sells;
		
	}
}
