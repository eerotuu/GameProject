using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public Player player;
	Text MoneyText;
	Text BulkText;
	Text objectiveStatus;
	Wallet wallet;
	Inventory invetory;
	DialogueManager dManager;

	string status;

	// Use this for initialization
	void Start ()
	{
		
		//DontDestroyOnLoad (this);
		MoneyText = (Text)GameObject.Find ("MoneyText").GetComponent<Text> ();
		BulkText = (Text)GameObject.Find ("BulkText").GetComponent<Text> ();
		objectiveStatus = (Text)GameObject.Find ("ObjectiveStatusText").GetComponent<Text> ();
		player = new Player ();
		SceneManager.LoadScene ("hospital", LoadSceneMode.Additive);
		//SceneManager.LoadScene ("city", LoadSceneMode.Additive);
		//GameObject.Find ("Player").transform.position = new Vector2 (82f, -88f);


		//invetory = GameObject.Find ("inven").GetComponent<Inventory> ();

		objectiveStatus.text = "is this ok?";
	}
		
	// Update is called once per frame
	void Update ()
	{
		MoneyText.text = "Money: " + player.wallet.GetSaldo () + "$";
		BulkText.text = "Bulk: " + player.GetBulk () + " kcal";
		objectiveStatus.text = status;

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
