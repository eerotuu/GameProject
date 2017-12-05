using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
	QuestNPC questNPC;
	MerchantNPC merchantNPC;
	int productPrice;
	int productKcal;

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
	GameItem poison;


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

		if (StaticObjects.QUEST_FAKEDOCTOR > 1 && GameObject.Find ("FakeDoctorObjectiveNPC") && !yes.getPressed ()) {
			dialogueBox.SetActive (false);
			DestroyObject (GameObject.Find ("FakeDoctorObjectiveNPC"));
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

			switch (currentNpc) {
			case DialogueMap.BRGCLUB:
				BuyProduct (DialogueMap.BRGCLUB);
				break;
			case DialogueMap.Le_AFFAME:
				BuyProduct (DialogueMap.Le_AFFAME);
				break;
			case DialogueMap.SHISH:
				BuyProduct (DialogueMap.SHISH);
				break;
			case DialogueMap.THE_BOGO:
				BuyProduct (DialogueMap.THE_BOGO);
				break;
			case DialogueMap.TOUGH:
				BuyProduct (DialogueMap.TOUGH);
				break;
			}



			if (currentNpc.Equals ("Bob Burger")) {
				if (gameController.player.wallet.GetSaldo () >= 10) {
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
		if (isActive) {
			if (yes.getPressed () && !pressed) { //!!! DON'T CHANGE THIS && !pressed
				pressed = true;

				//NEW SYSTEM
				switch (currentNpc) {
				case DialogueMap.VEGANVILLE_MAFIA:
					if (StaticObjects.QUEST_FAKEDOCTOR == 0) {
						dialogueText.text = dialogueMap.GetDialogue (DialogueMap.VEGANVILLE_MAFIA + DialogueMap.STEP_1);
						//questNPC.ChangeStatus (DialogueMap.STEP_2, false);
						StaticObjects.MAFIA_STATUS = DialogueMap.STEP_2;
						StaticObjects.MAFIA_HASQUESTION = true;
						StaticObjects.QUEST_FAKEDOCTOR += 1;
						poison = new GameItem ("poison", "poison");
						gameController.player.inventory.AddItem (poison);
						gameController.player.inventory.ListInventory ();
						StaticObjects.OBJECTIVE_FAKE_DOCTOR_HASQUESTION = true;
						StaticObjects.OBJECTIVE_FAKE_DOCTOR_STATUS = DialogueMap.STEP_1;
						//GameObject.Find ("FakeDoctorObjectiveNPC").GetComponent<QuestNPC> ().hasQuestion = true; // del this later.
						//GameObject.Find ("FakeDoctorObjectiveNPC").GetComponent<QuestNPC> ().questStatus = DialogueMap.STEP_1; // del this later,
					} else if (StaticObjects.QUEST_FAKEDOCTOR == 2) {
						gameController.player.wallet.AddMoney (1000);
						dialogueText.text = dialogueMap.GetDialogue (DialogueMap.VEGANVILLE_MAFIA + DialogueMap.STEP_3);
						StaticObjects.MAFIA_STATUS = DialogueMap.STEP_4;
					} else {
						dialogueText.text = "Liar. Go do your job if wish to claim the reward.";
					}
					break;
				case DialogueMap.DOCTOR_DICK:
					dialogueText.text = dialogueMap.GetDialogue (DialogueMap.DOCTOR_DICK + DialogueMap.STEP_1);
					questNPC.ChangeStatus (DialogueMap.STEP_1, false);
					StaticObjects.DOCTOR_DICK_STATUS = DialogueMap.STEP_1;
					StaticObjects.DOCTOR_DICK_HASQUESTION = false;
					StaticObjects.GOT_MEDS = true;
					if (StaticObjects.TALKED_TO_NANCY) {
						GameObject.Find ("nurse1").GetComponent<QuestNPC> ().ChangeStatus (DialogueMap.DEFAULT, true);
						StaticObjects.NURSE_NANCY_HASQUESTION = true;
					}
					break;
				case DialogueMap.NURSE_NANCY:
					if (ObjectiveStatus == 0 && StaticObjects.GOT_MEDS) {
						medicine = new GameItem ("medicine", "meds");
						gameController.player.inventory.AddItem (medicine);
						gameController.player.inventory.ListInventory ();
						ObjectiveStatus += 1;
						dialogueText.text = dialogueMap.GetDialogue (DialogueMap.NURSE_NANCY + DialogueMap.STEP_2);
						questNPC.ChangeStatus (DialogueMap.STEP_3, false);
						StaticObjects.NURSE_NANCY_STATUS = DialogueMap.STEP_3;
						StaticObjects.NURSE_NANCY_HASQUESTION = false;
					} else if (!StaticObjects.GOT_MEDS && !StaticObjects.TALKED_TO_NANCY) {
						dialogueText.text = dialogueMap.GetDialogue (DialogueMap.NURSE_NANCY + DialogueMap.STEP_1);
						questNPC.ChangeStatus (DialogueMap.STEP_1, false);
						StaticObjects.NURSE_NANCY_STATUS = DialogueMap.STEP_1;
						StaticObjects.NURSE_NANCY_HASQUESTION = false;
						StaticObjects.TALKED_TO_NANCY = true;
					}
					break;
				case DialogueMap.BAD_LUCK_BRIAN:
					if (StaticObjects.QUEST_FAKEDOCTOR == 1) {
						StaticObjects.QUEST_FAKEDOCTOR += 1;
						gameController.player.inventory.RemoveItem (poison);
						gameController.player.inventory.ListInventory ();
						//StaticObjects.MAFIA_STATUS = DialogueMap.STEP_3;
					}
					break;
				}
				//Doctor Dick Dialogue
				/*if (currentNpc.Equals (DialogueMap.DOCTOR_DICK) && !StaticObjects.GOT_MEDS) {
					dialogueText.text = dialogueMap.GetDialogue (DialogueMap.DOCTOR_DICK); 
					iNpc.ChangeDialogueStatus (npc, dialogueMap.GetDialogue (DialogueMap.DOCTOR_DICK), false, false);
					if (StaticObjects.TALKED_TO_NANCY) {
						iNpc.ChangeDialogueStatus (iNpc.NurseNancy, "Alright here is your meds. Stay healthy!", false, false);
					}
					StaticObjects.GOT_MEDS = true;
				}*/

				//Nurse Nancy Dialogue
				/*if (ObjectiveStatus == 0 && (currentNpc.Equals (DialogueMap.NURSE_NANCY) && StaticObjects.GOT_MEDS || currentNpc.Equals (DialogueMap.NURSE_NANCY) && StaticObjects.GOT_MEDS && StaticObjects.TALKED_TO_NANCY)) {
					medicine = new GameItem ("medicine", "meds");
					gameController.player.inventory.AddItem (medicine);
					gameController.player.inventory.ListInventory ();
					ObjectiveStatus += 1;
					dialogueText.text = dialogueMap.GetDialogue (DialogueMap.NURSE_NANCY);
					iNpc.ChangeDialogueStatus (npc, "You already got your meds junkie!", false, false);
				} else if (currentNpc.Equals (DialogueMap.NURSE_NANCY) && !StaticObjects.GOT_MEDS && !StaticObjects.TALKED_TO_NANCY) {
					dialogueText.text = "Go talk to Doctor Dick first";
					StaticObjects.TALKED_TO_NANCY = true;
				}*/

				//Drug Buyer's Dialogue
				if (ObjectiveStatus == 2 && currentNpc.Equals ("Drug Buyer")) {
					gameController.player.inventory.RemoveItem (medicine);
					gameController.player.inventory.ListInventory ();
					dialogueText.text = "Cool! You'll get 20$ for this junk\n\nIf you find more.. stuff.. to sell come see me.";
					gameController.player.wallet.AddMoney (20);
					ObjectiveStatus += 1;
					gameController.ChangeObjective ("Gain your daily 1500kcal");
				} else if (ObjectiveStatus != 2 && currentNpc.Equals ("Drug Buyer")) {
					dialogueText.text = "Liar!";
				}

				if (currentNpc.Equals ("Man")) {
					StaticObjects.OBJECTIVE_VEGAN_BEATED = true;
					gameController.player.wallet.AddMoney (50);
					GameItem key = new GameItem ("key", "key");
					gameController.player.inventory.AddItem (key);
					gameController.player.inventory.ListInventory ();
				}

			}

			//WHEN NO IS PRESSED IN DIALOGUE
			if (no.getPressed () && !pressed) { 
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

	public void SideQuestDialogue (QuestNPC questNpc, string name, bool hasQuestion, string status)
	{
		if (!isActive) {
			isActive = true;
			questNPC = questNpc;
			dialogueButtons.SetActive (hasQuestion);
			dialogueButtonsSell.SetActive (false);
			dialogueOkButton.SetActive (false);
			currentNpc = name;
			dialgueName.text = name + ":";
			dialogueText.text = dialogueMap.GetDialogue (name + status);
			locked = true;
			isLocked = true;
		}

	}

	public void MerchantDialogue (MerchantNPC merchantNpc, string merchant, string product, int price, int kcal)
	{
		if (!isActive) {
			isActive = true;
			this.merchantNPC = merchantNpc;
			dialogueButtons.SetActive (false);
			dialogueButtonsSell.SetActive (true);
			dialogueOkButton.SetActive (false);
			currentNpc = merchant;
			dialgueName.text = merchant + ":";
			dialogueText.text = dialogueMap.GetDialogue (merchant + DialogueMap.DEFAULT);
			locked = true;
			isLocked = true;
			this.productPrice = price;
			this.productKcal = kcal;
		}
		
	}

	void BuyProduct (string merchant)
	{
		if (gameController.player.wallet.GetSaldo () >= productPrice) {
			dialogueText.text = dialogueMap.GetDialogue (merchant + DialogueMap.STEP_1);
			gameController.player.AddBulk (productKcal);
			gameController.player.wallet.UseMoney (productPrice);
		}
	}
		
}
