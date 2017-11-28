using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public GameObject dialogueBox;
	public GameObject dialogueButtons;
	public GameObject dialogueButtonsSell;

	private PointerController interact;
	private PointerController buy;
	private PointerController yes;
	private PointerController no;

	private GameController gameController;

	string currentNpc;

	float locked;
	float textLocked;

	public Text dialgueName;
	public Text dialogueText;

	public bool isActive;
	public bool isLocked;


	// Use this for initialization
	void Start ()
	{
		isActive = false;
		interact = GameObject.Find ("Interact").GetComponent<PointerController> ();
		buy = GameObject.Find ("Buy1").GetComponent<PointerController> ();
		yes = GameObject.Find ("DialogueButtonYes").GetComponent<PointerController> ();
		no = GameObject.Find ("DialogueButtonNo").GetComponent<PointerController> ();
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isActive && interact.getPressed () && Time.time > locked) {
			isActive = false;
			locked = Time.time + 1.0F;
		}

		if (!isActive && Time.time > locked) {
			isLocked = false;
		}

		//BUY
		if (isActive && buy.getPressed () && Time.time > textLocked) {
			if (currentNpc.Equals ("Fast Food Joe")) {
				if (gameController.player.wallet.GetSaldo () > 0) {
					gameController.player.AddBulk (300);
					gameController.player.wallet.UseMoney (10);
					Debug.Log ("Bought CheeseBurger!");
					textLocked = Time.time + 0.5F;
					dialogueText.text = "There you go son, one CheeseBurger.";
				} else {
					dialogueText.text = "Son, you poor as fuck! \nGo get some money first.";
				}
			}
		}

		//YES
		if (isActive && yes.getPressed () && Time.time > textLocked) {
			if (currentNpc.Equals ("Doctor Dick")) {
				dialogueButtons.SetActive (false);
				dialogueText.text = "Thats good you are changing your habits!\nGo fetch your meds from Nurse Nancy and you are free to go.";
				textLocked = Time.time + 0.5F;

			}
		}

		//NO
		if (isActive && no.getPressed () && Time.time > textLocked) {
			if (currentNpc.Equals ("Doctor Dick")) {
				
			}
		}
		dialogueBox.SetActive (isActive);
	}

	public void Dialogue (string name, string text, bool hasQuestion, bool sells)
	{
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
