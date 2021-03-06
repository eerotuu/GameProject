﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactive NPC control. OLD SYSTEM, only controls few npc that isn't moved to new system.
/// </summary>
public class InteractiveNPC : MonoBehaviour
{

	public bool talks;

	DialogueManager dManager;

	public Npc BurgerBob;
	public Npc FastFoodJoe;
	public Npc DoctorDick;
	public Npc DoctorNick;
	public Npc NurseNancy;
	public Npc hospitalDoor;
	public Npc DrugBuyer;
	public Npc FemaleVegan;
	public Npc MaleVegan;


	// Use this for initialization
	void Start ()
	{
		dManager = GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ();
		FastFoodJoe = new Npc ("Fast Food Joe", "Hi! Welcome to Fast Food Joe's Crib.\nWould you like to buy a CheeseBurger for 10$?", true, false);
		BurgerBob = new Npc ("Bob Burger", "Hi! Welcome to Bob's Burgers.\nWould you like to buy a CheeseBurger for 10$?", true, false);
		DoctorDick = new Npc ("Doctor Dick", "So... Bobby Ulk. I'm worried about your bulking habit. I need you to start healthy diet and stop this fast food madness.\n\nAre you OK with this?", false, true);
		DoctorNick = new Npc ("Doctor Nick", "HURRRDDURRRR.......", false, true);
		NurseNancy = new Npc ("Nurse Nancy", "Hi!\nAre you here for your meds?", false, true);
		hospitalDoor = new Npc ("Doctor Dick", "HEY! GET YOUR MEDS FIRST!", false, false);
		DrugBuyer = new Npc ("Drug Buyer", "Yo Bobby, got something to sell?", false, true);
		FemaleVegan = new Npc ("Woman", "Hi. I'm vegan.", false, false);
		MaleVegan = new Npc ("Man", "Hi. I'm vegan.", false, false);
	}

	/// <summary>
	/// Talk the specified npc and iNpc.
	/// </summary>
	/// <param name="npc">Npc.</param>
	/// <param name="iNpc">I npc.</param>
	public void Talk (Npc npc, InteractiveNPC iNpc)
	{
		if (!dManager.isLocked) {
			dManager.Dialogue (iNpc, npc, npc.name, npc.message, npc.hasQuestion, npc.sells);
		}

	}

	/// <summary>
	/// Stops the talk.
	/// </summary>
	public void StopTalk ()
	{
		dManager.isActive = false;
		dManager.isLocked = false;
	}

	/// <summary>
	/// Changes the dialogue status.
	/// </summary>
	/// <param name="npc">Npc.</param>
	/// <param name="message">Message.</param>
	/// <param name="hasQuestion">If set to <c>true</c> has question.</param>
	/// <param name="sells">If set to <c>true</c> sells.</param>
	public void ChangeDialogueStatus (Npc npc, string message, bool hasQuestion, bool sells)
	{
		npc.message = message;
		npc.hasQuestion = hasQuestion;
		npc.sells = sells;
		
	}
}
