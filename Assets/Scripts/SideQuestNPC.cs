using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideQuestNPC : MonoBehaviour
{
	public string name;
	public string quest;
	public bool hasQuestion;

	public void Talk ()
	{
		DialogueManager.SideQuestDialogue (name, hasQuestion);
	}
}
