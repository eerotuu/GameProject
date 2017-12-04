using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

/// <summary>
/// Dialogue manager.
/// </summary>
public class DialogueManager : MonoBehaviour
{
	//GAMECONTROLLER
	private GameController gameController;

	//DIALOGUEMAP
	private DialogueMap dialogueMap;

	//NPC VARIABLES
	InteractiveNPC iNpc;
	string currentNpc;
	Npc npc;

	//DIALOGUE BUTTONS.
	public GameObject dialogueBox;
	public GameObject dialogueButtons;
	public GameObject dialogueButtonsSell;
	public GameObject dialogueOkButton;

	private PointerController interact;
	private PointerController buy;
	private PointerController yes;
	private PointerController no;
	private PointerController ok;

	//GAMEOBJECTIVE AND DIALOGUE STATUSES.
	public int ObjectiveStatus;

	//GAME OBJECTS.
	GameItem medicine;


	//For Locking Dialogue Boxes.
	bool locked;
	float textLocked;

	//Dialogue text variables.
	public Text dialgueName;
	public Text dialogueText;

	//For checking Dialogue Box Status.
	public bool isActive;
	public bool isLocked;

	//For Checking That no button is pressed before hiding them.
	bool pressed;
	bool okPressed;


	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{
		isActive = false;
		interact = GameObject.Find ("Interact").GetComponent<PointerController> ();
		buy = GameObject.Find ("Buy1").GetComponent<PointerController> ();
		yes = GameObject.Find ("DialogueButtonYes").GetComponent<PointerController> ();
		no = GameObject.Find ("DialogueButtonNo").GetComponent<PointerController> ();
		ok = GameObject.Find ("DialogueOkButton").GetComponent<PointerController> ();

		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		ObjectiveStatus = 0;
		gameController.ChangeObjective ("Leave Hospital");
		yes.getPressed ();
		dialogueButtons.SetActive (false);

		dialogueMap = new DialogueMap ();

	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{
		CheckPressed ();
		dialogueBox.SetActive (isActive);

		if (StaticObjects.OBJECTIVE_VEGAN_BEATED && GameObject.Find ("objectiveVegan") && !yes.getPressed ()) {
			dialogueBox.SetActive (false);
			DestroyObject (GameObject.Find ("objectiveVegan"));
		}

		if (isActive && interact.getPressed () && !locked) {
			isActive = false;
			locked = true;
		}

		if (!isActive && !locked) {
			isLocked = false;

		}
		if (isActive && ok.getPressed () && !okPressed) {
			okPressed = true;
		}

		//BUY
		if (isActive && currentNpc.Equals (DialogueMap.BOB_BURGER) && StaticObjects.OBJECTIVE_VEGAN_BEATED && !StaticObjects.FREE_CHEESEBURGER_GAINED) {
			gameController.player.AddBulk (300);
			dialogueText.text = "Oh you got him to leave? Here is one cheeseburger as promised. \n\nWould you like to buy more?";
			StaticObjects.FREE_CHEESEBURGER_GAINED = true;
		}
		 
		if (isActive && buy.getPressed () && !pressed) { //!!! DON'T CHANGE THIS
			pressed = true;
			if (currentNpc.Equals ("Bob Burger")) {
				if (gameController.player.wallet.GetSaldo () > 0) {
					gameController.player.AddBulk (300);
					gameController.player.wallet.UseMoney (10);
					Debug.Log ("Bought CheeseBurger!");
					dialogueText.text = "There you go son, one CheeseBurger.";

					if (!StaticObjects.OBJECTIVE_VEGAN_BEATED) {
						dialogueText.text += "\n\nIf you can drive off that annoying vegan outside, I'll give you a free burger.";
						StaticObjects.FREE_CHEESEBURGER = true;
					}

				} else {
					dialogueText.text = "Son, you poor as fuck!";
					if (!StaticObjects.OBJECTIVE_VEGAN_BEATED) {
						dialogueText.text += "\n\nIf you can drive off that annoying vegan lady outside I'll give you free burger.";
						StaticObjects.FREE_CHEESEBURGER = true;
					} else {
						dialogueText.text += "\nGo get some money first.";
					}
				}
			}
		}



		//WHEN YES PRESSED IN DIALOGUE
		if (isActive && yes.getPressed () && !pressed) { //!!! DON'T CHANGE THIS && !pressed
			pressed = true;

			//Doctor Dick Dialogue
			if (currentNpc.Equals (DialogueMap.DOCTOR_DICK) && !StaticObjects.GOT_MEDS) {
				dialogueText.text = dialogueMap.GetDialogue (DialogueMap.DOCTOR_DICK); // "Thats good you are changing your habits!\nGo fetch your meds from Nurse Nancy and you are free to go.";
				iNpc.ChangeDialogueStatus (npc, dialogueMap.GetDialogue (DialogueMap.DOCTOR_DICK), false, false);
				if (StaticObjects.TALKED_TO_NANCY) {
					iNpc.ChangeDialogueStatus (iNpc.NurseNancy, "Alright here is your meds. Stay healthy!", false, false);
				}
				StaticObjects.GOT_MEDS = true;
			}

			//Nurse Nancy Dialogue
			if (ObjectiveStatus == 0 && (currentNpc.Equals (DialogueMap.NURSE_NANCY) && StaticObjects.GOT_MEDS || currentNpc.Equals (DialogueMap.NURSE_NANCY) && StaticObjects.GOT_MEDS && StaticObjects.TALKED_TO_NANCY)) {
				medicine = new GameItem ("medicine", "meds");
				GameItem key = new GameItem ("key", "key");
				gameController.player.inventory.AddItem (medicine);
				gameController.player.inventory.AddItem (key);
				gameController.player.inventory.ListInventory ();
				ObjectiveStatus += 1;
				dialogueText.text = dialogueMap.GetDialogue (DialogueMap.NURSE_NANCY);
				iNpc.ChangeDialogueStatus (npc, "You already got your meds junkie!", false, false);
			} else if (currentNpc.Equals (DialogueMap.NURSE_NANCY) && !StaticObjects.GOT_MEDS && !StaticObjects.TALKED_TO_NANCY) {
				dialogueText.text = "Go talk to Doctor Dick first";
				StaticObjects.TALKED_TO_NANCY = true;
			}

			//Drug Buyer's Dialogue
			if (ObjectiveStatus == 2 && currentNpc.Equals ("Drug Buyer")) {
				gameController.player.inventory.RemoveItem (medicine);
				gameController.player.inventory.ListInventory ();
				dialogueText.text = "Cool! You'll get 20$ for this junk\n\nIf you find more.. stuff.. to sell come see me.";
				gameController.player.wallet.AddMoney (20);
				ObjectiveStatus += 1;
				gameController.ChangeObjective ("Gain your daily calories: 15000kcal");
			} else if (ObjectiveStatus != 2 && currentNpc.Equals ("Drug Buyer")) {
				dialogueText.text = "Liar!";
			}

			if (currentNpc.Equals ("Man")) {
				StaticObjects.OBJECTIVE_VEGAN_BEATED = true;
			}

		}

		//WHEN NO IS PRESSED IN DIALOGUE
		if (isActive && no.getPressed () && !pressed) { 
			pressed = true;

			//Doctor Dick Dialogue
			if (currentNpc.Equals (DialogueMap.DOCTOR_DICK) && !StaticObjects.GOT_MEDS) {
				dialogueText.text = "Sir. I Think You should reconsider.";
			}

			//Nurse Nancy Dialogue
			if (currentNpc.Equals (DialogueMap.NURSE_NANCY)) {
				dialogueText.text = "Ah...";
			}

			//Drug Buyer's Dialogue
			if (currentNpc.Equals ("Drug Buyer")) {
				dialogueText.text = "Fuck you too Bobby..";
			}

			if (currentNpc.Equals ("Man")) {
				dialogueText.text = "Filthy meat lover...";
			}
		}
			



	}

	/// <summary>
	/// Start dialogue for specified npc.
	/// </summary>
	/// <param name="iNpc">Interactive npc.</param>
	/// <param name="npc">Npc.</param>
	/// <param name="name">Name.</param>
	/// <param name="text">Text.</param>
	/// <param name="hasQuestion">If set to <c>true</c> has question.</param>
	/// <param name="sells">If set to <c>true</c> sells.</param>
	public void Dialogue (InteractiveNPC iNpc, Npc npc, string name, string text, bool hasQuestion, bool sells)
	{
		dialogueButtons.SetActive (true);
		if (!isActive) {
			Debug.Log ("Talking to: " + name);
			this.iNpc = iNpc;
			this.npc = npc;
			currentNpc = name;
			dialogueButtons.SetActive (hasQuestion);
			dialogueButtonsSell.SetActive (sells);
			dialogueOkButton.SetActive (false);
			isActive = true;
			dialgueName.text = name + ":";
			dialogueText.text = text;
			locked = true;
			isLocked = true;
		}
	}

	public void Dialogue (string name, string text)
	{
		if (!isActive) {
			dialogueButtons.SetActive (false);
			dialogueButtonsSell.SetActive (false);
			dialogueOkButton.SetActive (true);
			isActive = true;
			dialgueName.text = name + ":";
			dialogueText.text = text;
			locked = true;
			isLocked = true;
		}
	}

	/// <summary>
	/// Checks the pressed buttons and hides them if none is pressed.
	/// </summary>
	void CheckPressed ()
	{
		if (!yes.getPressed () && !no.getPressed () && !buy.getPressed () && pressed) {
			dialogueButtons.SetActive (false);
			pressed = false;
		}
		if (!interact.getPressed ()) {
			locked = false;
		}
		if (!ok.getPressed () && okPressed) {
			okPressed = false;
			isActive = false;
		}
	}


		
}
