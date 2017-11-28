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

		/*if (currentIntreactiveNPC) {
			if (npc == currentIntreactiveNPC.hospitalDoor) {
				currentIntreactiveNPC.Talk (npc, currentIntreactiveNPC);
			}
		}*/
		
	}

	//
	// Player Interaction With other objects
	//
	void OnTriggerEnter2D (Collider2D other)
	{
		//Hospial door out
		if (other.gameObject.name.Equals ("Door") && dManager.ObjectiveStatus > 0) {
			Debug.Log ("Scene Change");
			SceneManager.UnloadSceneAsync ("hospital");
			SceneManager.LoadScene ("city", LoadSceneMode.Additive);
			transform.position = new Vector2 (84f, -72.5f);
			dManager.ObjectiveStatus += 1;
			gameController.ChangeObjective ("Find a way to sell your meds");
		} else if (other.gameObject.name.Equals ("Door") && dManager.ObjectiveStatus == 0) {
			currentIntreactiveNPC = other.gameObject.GetComponent <InteractiveNPC> ();
			npc = currentIntreactiveNPC.hospitalDoor;
			currentIntreactiveNPC.Talk (npc, currentIntreactiveNPC);
		}
		//FastFood door 1 in
		if (other.gameObject.name.Equals ("FastFood_1_Door")) {
			Debug.Log ("Scene Change");
			SceneManager.UnloadSceneAsync ("city");
			SceneManager.LoadScene ("fastfood", LoadSceneMode.Additive);
			transform.position = new Vector2 (0f, -2.5f);
		}
		//FastFood door 1 out
		if (other.gameObject.name.Equals ("FastFood_1_Door_Out")) {
			Debug.Log ("Scene Change");

			SceneManager.UnloadSceneAsync ("fastfood");
			SceneManager.LoadScene ("city", LoadSceneMode.Additive);
			transform.position = new Vector2 (74f, -88.6f);
		}
		//FastFood door 2 in
		if (other.gameObject.name.Equals ("FastFood_2_Door")) {
			Debug.Log ("Scene Change");
			SceneManager.UnloadSceneAsync ("city");
			SceneManager.LoadScene ("fastfood2", LoadSceneMode.Additive);
			transform.position = new Vector2 (6f, -2.7f);
		}
		//FastFood door 2 out
		if (other.gameObject.name.Equals ("FastFood_2_Door_Out")) {
			Debug.Log ("Scene Change");

			SceneManager.UnloadSceneAsync ("fastfood2");
			SceneManager.LoadScene ("city", LoadSceneMode.Additive);
			transform.position = new Vector2 (82f, -88.6f);
		}

		//FastFood door 3 in
		if (other.gameObject.name.Equals ("FastFood_3_Door")) {
			Debug.Log ("Scene Change");
			SceneManager.UnloadSceneAsync ("city");
			SceneManager.LoadScene ("fastfood3", LoadSceneMode.Additive);
			transform.position = new Vector2 (-2f, -17.5f);
		}

		//FastFood door 3 Out
		if (other.gameObject.name.Equals ("FastFood_3_Door_Out")) {
			Debug.Log ("Scene Change");

			SceneManager.UnloadSceneAsync ("fastfood3");
			SceneManager.LoadScene ("city", LoadSceneMode.Additive);
			transform.position = new Vector2 (24.5f, -53.5f);
		}
		//FastFood door 4 in
		if (other.gameObject.name.Equals ("FastFood_4_Door")) {
			Debug.Log ("Scene Change");
			SceneManager.UnloadSceneAsync ("city");
			SceneManager.LoadScene ("fastfood4", LoadSceneMode.Additive);
			transform.position = new Vector2 (-2f, -17.5f);
		}

		//FastFood door 4 Out
		if (other.gameObject.name.Equals ("FastFood_4_Door_Out")) {
			Debug.Log ("Scene Change");

			SceneManager.UnloadSceneAsync ("fastfood4");
			SceneManager.LoadScene ("city", LoadSceneMode.Additive);
			transform.position = new Vector2 (37.3f, -53.5f);
		}

		//FastFood door 5 in	
		if (other.gameObject.name.Equals ("FastFood_5_Door")) {
			Debug.Log ("Scene Change");

			SceneManager.UnloadSceneAsync ("city");
			SceneManager.LoadScene ("fastfood5", LoadSceneMode.Additive);
			transform.position = new Vector2 (0f, -1.2f);
		}

		//FastFood 5 out
		if (other.gameObject.name.Equals ("FastFood_5_Door_Out")) {
			Debug.Log ("Scene Change");

			SceneManager.UnloadSceneAsync ("fastfood5");
			SceneManager.LoadScene ("city", LoadSceneMode.Additive);
			transform.position = new Vector2 (52f, -89.5f);
		}
		//Restaurant door 5 in	
		if (other.gameObject.name.Equals ("Restaurant_Door")) {
			Debug.Log ("Scene Change");

			SceneManager.UnloadSceneAsync ("city");
			SceneManager.LoadScene ("restaurant", LoadSceneMode.Additive);
			transform.position = new Vector2 (-4.5f, -12.5f);
		}

		//Restaurant 5 out
		if (other.gameObject.name.Equals ("Restaurant_Door_Out")) {
			Debug.Log ("Scene Change");

			SceneManager.UnloadSceneAsync ("restaurant");
			SceneManager.LoadScene ("city", LoadSceneMode.Additive);
			transform.position = new Vector2 (108f, -74.5f);
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

	}

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

