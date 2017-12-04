using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

	public InteractiveNPC currentIntreactiveNPC;
	Npc npc;
	PointerController interact;
	Image iButton;
	GameController gameController;

	DialogueManager dManager;

	// Use this for initialization
	void Start ()
	{
		interact = GameObject.Find ("Interact").GetComponent<PointerController> ();
		iButton = GameObject.Find ("Interact").GetComponent<Image> ();
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		dManager = GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (interact.getPressed () && currentIntreactiveNPC) {
			if (currentIntreactiveNPC.talks) {
				currentIntreactiveNPC.Talk (npc, currentIntreactiveNPC);
			}

		}
		
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D (Collider2D other)
	{
		//Hospial door out
		if (other.gameObject.name.Equals ("Door") && dManager.ObjectiveStatus > 0) {
			gameController.ChangeScene ("hospital", "city", 84f, -72.5f);
			if (dManager.ObjectiveStatus == 1) {
				dManager.ObjectiveStatus += 1;
				gameController.ChangeObjective ("Find a way to sell your meds");
				dManager.Dialogue ("Me", "I should go see my buddy at southwest from here. That junkie definitely buys this shit.");
			}
		} else if (other.gameObject.name.Equals ("Door") && dManager.ObjectiveStatus == 0) {
			currentIntreactiveNPC = other.gameObject.GetComponent <InteractiveNPC> ();
			npc = currentIntreactiveNPC.hospitalDoor;
			currentIntreactiveNPC.Talk (npc, currentIntreactiveNPC);
		}
		if (other.gameObject.name.Equals ("Hospital_Door")) {
			gameController.ChangeScene ("city", "hospital", 7f, -17f);
		}
		//FastFood door 1 in
		if (other.gameObject.name.Equals ("FastFood_1_Door")) {
			gameController.ChangeScene ("city", "fastfood", 0f, -2.5f);
		}
		//FastFood door 1 out
		if (other.gameObject.name.Equals ("FastFood_1_Door_Out")) {
			gameController.ChangeScene ("fastfood", "city", 74f, -88.6f);
		}
		//FastFood door 2 in
		if (other.gameObject.name.Equals ("FastFood_2_Door")) {
			gameController.ChangeScene ("city", "fastfood2", 6f, -2.7f);
		}
		//FastFood door 2 out
		if (other.gameObject.name.Equals ("FastFood_2_Door_Out")) {
			gameController.ChangeScene ("fastfood2", "city", 82f, -88.6f);
		}

		//FastFood door 3 in
		if (other.gameObject.name.Equals ("FastFood_3_Door")) {
			gameController.ChangeScene ("city", "fastfood3", -2f, -17.5f);
		}

		//FastFood door 3 Out
		if (other.gameObject.name.Equals ("FastFood_3_Door_Out")) {
			gameController.ChangeScene ("fastfood3", "city", 24.5f, -53.5f);
		}
		//FastFood door 4 in
		if (other.gameObject.name.Equals ("FastFood_4_Door")) {
			gameController.ChangeScene ("city", "fastfood4", -2f, -17.5f);

		}

		//FastFood door 4 Out
		if (other.gameObject.name.Equals ("FastFood_4_Door_Out")) {
			gameController.ChangeScene ("fastfood4", "city", 37.3f, -53.5f);
		}

		//FastFood door 5 in	
		if (other.gameObject.name.Equals ("FastFood_5_Door")) {
			gameController.ChangeScene ("city", "fastfood4", 0f, -1.2f);
		}

		//FastFood 5 out
		if (other.gameObject.name.Equals ("FastFood_5_Door_Out")) {
			gameController.ChangeScene ("fastfood5", "city", 52f, -89.5f);
		}
		//Restaurant door in	
		if (other.gameObject.name.Equals ("Restaurant_Door")) {
			gameController.ChangeScene ("city", "restaurant", -4.5f, -12.5f);
		}

		//Restaurant out
		if (other.gameObject.name.Equals ("Restaurant_Door_Out")) {
			gameController.ChangeScene ("restaurant", "city", 108f, -74.5f);
		}

		//coin
		if (other.gameObject.name.Equals ("Coin")) {
			gameController.player.wallet.AddMoney (10);

			Destroy (other.gameObject);
		}

		//merchant in fasfood1
		if (other.gameObject.name.Equals ("FastFoodMerchant")) {
			iButton.color = Color.green;
			currentIntreactiveNPC = other.gameObject.GetComponent <InteractiveNPC> ();
			npc = currentIntreactiveNPC.FastFoodJoe;
		}
		if (other.gameObject.name.Equals ("BurgerBob")) {
			iButton.color = Color.green;
			currentIntreactiveNPC = other.gameObject.GetComponent <InteractiveNPC> ();
			npc = currentIntreactiveNPC.BurgerBob;
		}

		//NPC INTERACTION

		//Doctor in hospital
		if (other.gameObject.name.Equals ("doctor")) {
			iButton.color = Color.green;
			currentIntreactiveNPC = other.gameObject.GetComponent <InteractiveNPC> ();
			npc = currentIntreactiveNPC.DoctorDick;
		}

		if (other.gameObject.name.Equals ("doctor2")) {
			iButton.color = Color.green;
			currentIntreactiveNPC = other.gameObject.GetComponent <InteractiveNPC> ();
			npc = currentIntreactiveNPC.DoctorNick;
		}

		if (other.gameObject.name.Equals ("nurse1")) {
			iButton.color = Color.green;
			currentIntreactiveNPC = other.gameObject.GetComponent <InteractiveNPC> ();
			npc = currentIntreactiveNPC.NurseNancy;
		}

		if (other.gameObject.name.Equals ("DrugBuyer")) {
			iButton.color = Color.green;
			currentIntreactiveNPC = other.gameObject.GetComponent <InteractiveNPC> ();
			npc = currentIntreactiveNPC.DrugBuyer;
		}
		if (other.gameObject.name.Equals ("objectiveVegan")) {
			iButton.color = Color.green;
			currentIntreactiveNPC = other.gameObject.GetComponent <InteractiveNPC> ();
			npc = currentIntreactiveNPC.MaleVegan;
			if (dManager.ObjectiveStatus == 4) {
				currentIntreactiveNPC.ChangeDialogueStatus (npc, "Hi I'm Vegan\n\n\"Beat him?\"", true, false);
			}


		}

	}

	/// <summary>
	/// Raises the trigger exit2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.GetComponent <InteractiveNPC> ()) {
			InteractiveNPC npcCheck = other.gameObject.GetComponent <InteractiveNPC> ();
			if (npcCheck.talks) {
				currentIntreactiveNPC.StopTalk ();
				currentIntreactiveNPC = null;
				iButton.color = Color.white;

			}
		}
	}
		
}

