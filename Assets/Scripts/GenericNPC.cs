using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic NPC.
/// </summary>
public class GenericNPC : MonoBehaviour
{


	public bool talks;
	public string name;
	public string message;


	/// <summary>
	/// Starts Dialogue for this NPC
	/// </summary>
	public void Talk ()
	{
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().Dialogue (name, message);
	}

	/// <summary>
	/// Stops the talk.
	/// </summary>
	public void StopTalk ()
	{
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().isActive = false;
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().isLocked = false;
	}
}
