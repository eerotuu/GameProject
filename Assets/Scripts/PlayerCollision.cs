using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Player collision.
/// </summary>
public class PlayerCollision : MonoBehaviour
{
	//current InteractiveNPC, OLD DIALOGUE SYSTEM.
	public InteractiveNPC currentIntreactiveNPC;
	//current GenericNPC, npc with no questions.
	GenericNPC currentGenericNpc;
	//current QuestNPC, has status that affect his dialogue and questions.
	QuestNPC currentQuestNpc;
	//current MerchantNPC, has buttons that affect dialogue and products he sells.
	MerchantNPC currentMerchant;
	//CurrentNPC, OLD DIALOGUE SYSTEM.
	Npc npc;
	//Saves button controller for interact button.
	PointerController interact;
	//image for what??
	Image iButton;
	//Saves GameController.
	GameController gameController;
	//Saves Dialogue Manager.
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
		if ((interact.getPressed () || Input.GetKey ("space")) && currentIntreactiveNPC) {
			if (currentIntreactiveNPC.talks) {
				currentIntreactiveNPC.Talk (npc, currentIntreactiveNPC);
			}

		}

		if (interact.getPressed () || Input.GetKey ("space")) {
			if (currentGenericNpc) {
				if (currentGenericNpc.talks) {
					currentGenericNpc.Talk ();
				}
			}

			if (currentQuestNpc) {
				currentQuestNpc.Talk ();
			}

			if (currentMerchant) {
				currentMerchant.Talk ();
			}
		}
		
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.GetComponent<GenericNPC> ()) {
			currentGenericNpc = other.gameObject.GetComponent <GenericNPC> ();
			iButton.color = Color.green;
		}
		if (other.gameObject.GetComponent<QuestNPC> ()) {
			currentQuestNpc = other.gameObject.GetComponent <QuestNPC> ();
			iButton.color = Color.green;
		}
		if (other.gameObject.GetComponent<MerchantNPC> ()) {
			currentMerchant = other.gameObject.GetComponent <MerchantNPC> ();
			iButton.color = Color.green;
		}
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
			gameController.ChangeScene ("city", "fastfood5", 0f, -1.2f);
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
			gameController.player.wallet.AddMoney (10000);

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

		if (other.gameObject.name.Equals ("DrugBuyer")) {
			iButton.color = Color.green;
			currentIntreactiveNPC = other.gameObject.GetComponent <InteractiveNPC> ();
			npc = currentIntreactiveNPC.DrugBuyer;
		}
		if (other.gameObject.name.Equals ("objectiveVegan")) {
			iButton.color = Color.green;
			currentIntreactiveNPC = other.gameObject.GetComponent <InteractiveNPC> ();
			npc = currentIntreactiveNPC.MaleVegan;
			if (StaticObjects.FREE_CHEESEBURGER) {
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

		if (other.gameObject.GetComponent <GenericNPC> ()) {
			GenericNPC npcCheck = other.gameObject.GetComponent <GenericNPC> ();
			if (npcCheck.talks) {
				currentGenericNpc.StopTalk ();
				currentGenericNpc = null;
				iButton.color = Color.white;

			}
		}

		if (other.gameObject.GetComponent <QuestNPC> ()) {
			QuestNPC npcCheck = other.gameObject.GetComponent <QuestNPC> ();
			currentQuestNpc.StopTalk ();
			currentQuestNpc = null;
			iButton.color = Color.white;


		}

		if (other.gameObject.GetComponent <MerchantNPC> ()) {
			MerchantNPC npcCheck = other.gameObject.GetComponent <MerchantNPC> ();
			currentMerchant.StopTalk ();
			currentMerchant = null;
			iButton.color = Color.white;


		}
	}
		
}

