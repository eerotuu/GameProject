using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// QuestNPC Control.
/// </summary>
public class QuestNPC : MonoBehaviour
{
	//Name for npc
	public string name;
	//Does npc have a question.
	public bool hasQuestion;
	//Current QuestStatus.
	public string questStatus;



	void Start ()
	{
		questStatus = DialogueMap.DEFAULT;

	}

	void Update ()
	{
		switch (name) {
		case DialogueMap.DOCTOR_DICK:
			questStatus = StaticObjects.DOCTOR_DICK_STATUS;
			hasQuestion = StaticObjects.DOCTOR_DICK_HASQUESTION; 
			break;
		case DialogueMap.NURSE_NANCY:
			questStatus = StaticObjects.NURSE_NANCY_STATUS;
			hasQuestion = StaticObjects.NURSE_NANCY_HASQUESTION;
			break;
		case DialogueMap.VEGANVILLE_MAFIA:
			questStatus = StaticObjects.MAFIA_STATUS;
			hasQuestion = StaticObjects.MAFIA_HASQUESTION;
			break;
		case DialogueMap.BAD_LUCK_BRIAN:
			questStatus = StaticObjects.OBJECTIVE_FAKE_DOCTOR_STATUS;
			hasQuestion = StaticObjects.OBJECTIVE_FAKE_DOCTOR_HASQUESTION;
			break;
		}
	}

	/// <summary>
	/// Opens talk dialogue for this npc
	/// </summary>
	public void Talk ()
	{
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().SideQuestDialogue (this, name, hasQuestion, questStatus);
	}

	/// <summary>
	/// Stops the talk.
	/// </summary>
	public void StopTalk ()
	{
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().isActive = false;
		GameObject.Find ("DialogueManager").GetComponent<DialogueManager> ().isLocked = false;
	}

	/// <summary>
	/// Changes the npc status.
	/// </summary>
	/// <param name="status">Status.</param>
	/// <param name="hasQuestion">If set to <c>true</c> has question.</param>
	public void ChangeStatus (string status, bool hasQuestion)
	{
		questStatus = status;
		this.hasQuestion = hasQuestion;
	}
}
