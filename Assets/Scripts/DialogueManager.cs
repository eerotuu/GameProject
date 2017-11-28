using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class DialogueManager : MonoBehaviour
{
	InteractiveNPC iNpc;

	public GameObject dialogueBox;
	public GameObject dialogueButtons;
	public GameObject dialogueButtonsSell;

	//private PointerController interact;
	private PointerController buy;
	private PointerController yes;
	private PointerController no;

	private bool meds;

	private GameController gameController;

	string currentNpc;

	float locked;
	float textLocked;

	public Text dialgueName;
	public Text dialogueText;

	public bool isActive;
	public bool isLocked;

	Npc npc;

	//GAME OBJECTS
	GameItem medicine = new GameItem ("medicine");


	//DIALOGUE STATUS VARIABLES
	bool talkedToNancy;
	public int ObjectiveStatus;


	bool pressed;
	//delete this

	// Use this for initialization
	void Start ()
	{
		isActive = false;
		//interact = GameObject.Find ("Interact").GetComponent<PointerController> ();
		buy = GameObject.Find ("Buy1").GetComponent<PointerController> ();
		yes = GameObject.Find ("DialogueButtonYes").GetComponent<PointerController> ();
		no = GameObject.Find ("DialogueButtonNo").GetComponent<PointerController> ();
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		ObjectiveStatus = 0;
		gameController.ChangeObjective ("Leave Hospital");
		yes.getPressed ();
		dialogueButtons.SetActive (false);

	}
	
	// Update is called once per frame
	void Update ()
	{
		

		/*if (isActive && interact.getPressed () && Time.time > locked) {
			isActive = false;
			locked = Time.time + 1.0F;
		}*/

		if (!isActive && Time.time > locked) {
			isLocked = false;

		}


		//BUY
		if (isActive && buy.getPressed () && !pressed) { //!!! DON'T CHANGE THIS
			pressed = true;
			if (currentNpc.Equals ("Fast Food Joe")) {
				if (gameController.player.wallet.GetSaldo () > 0) {
					gameController.player.AddBulk (300);
					gameController.player.wallet.UseMoney (10);
					Debug.Log ("Bought CheeseBurger!");
					dialogueText.text = "There you go son, one CheeseBurger.";
				} else {
					dialogueText.text = "Son, you poor as fuck! \nGo get some money first.";
				}
			}
		}


		CheckPressed ();
		//YES
		if (isActive && yes.getPressed () && !pressed) { //!!! DON'T CHANGE THIS
			pressed = true;

			if (currentNpc.Equals ("Doctor Dick") && !meds) {
				dialogueText.text = "Thats good you are changing your habits!\nGo fetch your meds from Nurse Nancy and you are free to go.";
				iNpc.ChangeDialogueStatus (npc, "Thats good you are changing your habits!\nGo fetch your meds from Nurse Nancy and you are free to go.", false, false);
				if (talkedToNancy) {
					iNpc.ChangeDialogueStatus (iNpc.NurseNancy, "Alright here is your meds. Stay healthy!", false, false);
				}
				meds = true;
			}
				
			if (ObjectiveStatus == 0 && (currentNpc.Equals ("Nurse Nancy") && meds || currentNpc.Equals ("Nurse Nancy") && meds && talkedToNancy)) {
				gameController.player.inventory.AddItem (medicine);
				gameController.player.inventory.ListInventory (medicine);
				ObjectiveStatus += 1;
				Debug.Log ("Added Meds into inventory");
				dialogueText.text = "Alright, here is your meds.\nStay healthy!";
				iNpc.ChangeDialogueStatus (npc, "You already got your meds junkie!", false, false);
			} else if (currentNpc.Equals ("Nurse Nancy") && !meds && !talkedToNancy) {
				dialogueText.text = "Go talk to Doctor Dick first";
				talkedToNancy = true;
			}

			if (ObjectiveStatus == 2 && currentNpc.Equals ("Drug Buyer")) {
				gameController.player.inventory.RemoveItem (medicine);
				gameController.player.inventory.ListInventory ();
				dialogueText.text = "Cool! You'll get 50$ for this junk\n\nIf you find more drugs to sell come see me.";
				gameController.player.wallet.AddMoney (50);
				ObjectiveStatus += 1;
				gameController.ChangeObjective ("");
			} else if (ObjectiveStatus != 2 && currentNpc.Equals ("Drug Buyer")) {
				dialogueText.text = "Liar!";
			}
				

		}

		//NO
		if (isActive && no.getPressed () && !pressed) { //!!! DON'T CHANGE THIS
			pressed = true;

			//Doctor Dick
			if (currentNpc.Equals ("Doctor Dick") && !meds) {
				dialogueText.text = "Sir. I Think You should reconsider.";
			}

			//Nurse Nancy
			if (currentNpc.Equals ("Nurse Nancy")) {
				dialogueText.text = "Ah...";
			}

			if (currentNpc.Equals ("Drug Buyer")) {
				dialogueText.text = "Fuck you too Bobby..";
			}

		}
			

		dialogueBox.SetActive (isActive);

	}

	public void Dialogue (InteractiveNPC iNpc, Npc npc, string name, string text, bool hasQuestion, bool sells)
	{
		dialogueButtons.SetActive (true);
		if (!isActive) {
			Debug.Log ("reset");
			this.iNpc = iNpc;
			this.npc = npc;
			currentNpc = name;
			dialogueButtons.SetActive (hasQuestion);
			dialogueButtonsSell.SetActive (sells);
			isActive = true;
			dialgueName.text = name + ":";
			dialogueText.text = text;
			locked = Time.time + 1.0F;
			isLocked = true;
		}
	}

	void CheckPressed ()
	{
		if (!yes.getPressed () && !no.getPressed () && !buy.getPressed () && pressed) {
			dialogueButtons.SetActive (false);
			pressed = false;
		}
	}
		
}
