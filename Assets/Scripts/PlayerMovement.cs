using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

	public float speed;
	private bool moving = false;
	private Rigidbody2D playerRigidbody;
	public Vector2 lastMove;
	public Vector2 move;
	Animator anim;
	AsyncOperation asyncLoad;


	PointerController up;
	PointerController down;
	PointerController left;
	PointerController right;

	static GameController gameController;


	// Use this for initialization
	void Start ()
	{
		up = GameObject.Find ("Up").GetComponent<PointerController> ();
		down = GameObject.Find ("Down").GetComponent<PointerController> ();
		left = GameObject.Find ("Left").GetComponent<PointerController> ();
		right = GameObject.Find ("Right").GetComponent<PointerController> ();
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		playerRigidbody.freezeRotation = true;

		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();


		lastMove.y = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		moving = false;

		if (up.getPressed ()) {
			playerRigidbody.AddForce (Vector2.up * speed);
			move = new Vector2 (0f, 1);
			lastMove = new Vector2 (0f, 1);
			playerRigidbody.angularVelocity = 0;
			moving = true;
		}

		if (down.getPressed ()) {
			playerRigidbody.AddForce (-Vector2.up * speed);
			move = new Vector2 (0f, -1);
			lastMove = new Vector2 (0f, -1);
			playerRigidbody.angularVelocity = 0;
			moving = true;
		}

		if (left.getPressed ()) {
			playerRigidbody.AddForce (-Vector2.right * speed);
			move = new Vector2 (-1, 0);
			lastMove = new Vector2 (-1, 0);
			playerRigidbody.angularVelocity = 0;
			moving = true;
		}

		if (right.getPressed ()) {
			playerRigidbody.AddForce (Vector2.right * speed);
			move = new Vector2 (1, 0);
			lastMove = new Vector2 (1, 0);
			playerRigidbody.angularVelocity = 0;
			moving = true;
		}

		//if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
			
		//	playerRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * speed, playerRigidbody.velocity.y);
		//	moving = true;
		//	lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);

		//	}
		//if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
		//	playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * speed);
		//	moving = true;
		//	lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));

		//}
		//if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5) {
		//	playerRigidbody.velocity = new Vector2 (0f, playerRigidbody.velocity.y);

		//}
		//if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
		//	playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, 0f);

		//}
			

		anim.SetFloat ("MoveX", move.x);
		anim.SetFloat ("MoveY", move.y);
		anim.SetBool ("Moving", moving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);


	}

	void OnTriggerEnter2D (Collider2D other)
	{

			if (other.gameObject.name.Equals ("Door")) {
				Debug.Log ("Scene Change");
				SceneManager.UnloadSceneAsync ("hospital");
				SceneManager.LoadScene ("city", LoadSceneMode.Additive);
				transform.position = new Vector2 (84f, -72.5f);
			}

			if (other.gameObject.name.Equals ("FastFood_1_Door")) {
				Debug.Log ("Scene Change");
				asyncLoad = SceneManager.UnloadSceneAsync ("city");
				SceneManager.LoadScene ("fastfood", LoadSceneMode.Additive);
				transform.position = new Vector2 (0f, -2.5f);
			}

			if (other.gameObject.name.Equals ("FastFood_1_Door_Out")) {
				Debug.Log ("Scene Change");

				SceneManager.UnloadSceneAsync ("fastfood");
				SceneManager.LoadScene ("city", LoadSceneMode.Additive);
				transform.position = new Vector2 (74f, -88.6f);
			}
				
			if (other.gameObject.name.Equals ("FastFood_2_Door")) {
				Debug.Log ("Scene Change");

				SceneManager.UnloadSceneAsync ("city");
				SceneManager.LoadScene ("fastfood2", LoadSceneMode.Additive);
				transform.position = new Vector2 (5.95f, -2.2f);
			}

			if (other.gameObject.name.Equals ("FastFood_2_Door_Out")) {
				Debug.Log ("Scene Change");

				SceneManager.UnloadSceneAsync ("fastfood2");
				SceneManager.LoadScene ("city", LoadSceneMode.Additive);
				transform.position = new Vector2 (52f, -89.5f);
			}

			if (other.gameObject.name.Equals ("Coin")) {
				gameController.player.wallet.AddMoney (10);

				Destroy (other.gameObject);
			}

	}
}


