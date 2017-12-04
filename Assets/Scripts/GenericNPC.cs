using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericNPC : MonoBehaviour
{


	public bool talks;
	public string name;
	public string message;



	public void Talk ()
	{
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().Dialogue (name, message);
	}

	public void StopTalk ()
	{
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().isActive = false;
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().isLocked = false;
	}
}
