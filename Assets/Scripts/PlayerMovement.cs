using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

	public float speed;
	private bool moving = false;
	private Rigidbody2D playerRigidbody;
	public Vector2 lastMove;
	public Vector2 move;
	Animator anim;


	PointerController up;
	PointerController down;
	PointerController left;
	PointerController right;



	// Use this for initialization
	void Start ()
	{
		up = GameObject.Find ("Up").GetComponent<PointerController> ();
		down = GameObject.Find ("Down").GetComponent<PointerController> ();
		left = GameObject.Find ("Left").GetComponent<PointerController> ();
		right = GameObject.Find ("Right").GetComponent<PointerController> ();
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		playerRigidbody.freezeRotation = true;
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
			

		anim.SetFloat ("MoveX", move.x);
		anim.SetFloat ("MoveY", move.y);
		anim.SetBool ("Moving", moving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);


	}
}


