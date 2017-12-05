using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Game controller. Handles player variables and scene change.
/// </summary>
public class GameController : MonoBehaviour
{
	public Player player;
	Text MoneyText;
	Text BulkText;
	Text objectiveStatus;
	Wallet wallet;
	Inventory invetory;
	DialogueManager dManager;
	PointerController exitButton;
	string status;

	// Use this for initialization
	void Start ()
	{
		StaticObjects.Reset ();
		MoneyText = (Text)GameObject.Find ("MoneyText").GetComponent<Text> ();
		BulkText = (Text)GameObject.Find ("BulkText").GetComponent<Text> ();
		objectiveStatus = (Text)GameObject.Find ("ObjectiveStatusText").GetComponent<Text> ();
		player = new Player ();
		SceneManager.LoadScene ("hospital", LoadSceneMode.Additive);
		exitButton = GameObject.Find ("Exit").GetComponent<PointerController> ();
		objectiveStatus.text = "is this ok?";
	}
		
	// Update is called once per frame
	void Update ()
	{
		MoneyText.text = "Money: " + player.wallet.GetSaldo () + "$";
		BulkText.text = "Bulk: " + player.GetBulk () + " kcal";
		objectiveStatus.text = status;

		if (exitButton.getPressed ()) {
			SceneManager.LoadScene ("main_menu");
			DestroyObject (GameObject.Find ("Music"));
		}

		if (player.GetBulk () >= 15000) {
			SceneManager.LoadScene ("end");
		} 


	}

	/// <summary>
	/// Changes the objective.
	/// </summary>
	/// <param name="objective">Objective.</param>
	public void ChangeObjective (string objective)
	{
		status = objective;

	}

	/// <summary>
	/// Changes the scene.
	/// </summary>
	/// <param name="sceneToUnload">Scene to unload.</param>
	/// <param name="sceneToLoad">Scene to load.</param>
	/// <param name="posX">Position x.</param>
	/// <param name="posY">Position y.</param>
	public void ChangeScene (string sceneToUnload, string sceneToLoad, float posX, float posY)
	{
		SceneManager.UnloadSceneAsync (sceneToUnload);
		SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Additive);
		GameObject.Find ("Player").transform.position = new Vector2 (posX, posY);
		Debug.Log ("Scene changed to " + sceneToLoad);


	}


}
