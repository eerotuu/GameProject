using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueMap
{
	public static string DOCTOR_DICK = "Doctor Dick";
	public static string NURSE_NANCY = "Nurse Nancy";
	public static string BOB_BURGER = "Bob Burger";
	public static Dictionary<string, string> dialogues = new Dictionary<string, string> ();

	public DialogueMap ()
	{
		AddDialogues ();
	}



	public string GetDialogue (string name)
	{	
		return dialogues [name];	
	}

	void AddDialogues ()
	{
		dialogues.Add (DOCTOR_DICK, "Thats good you are changing your habits!\nGo fetch your meds from Nurse Nancy and you are free to go.");
		dialogues.Add (NURSE_NANCY, "Alright, here is your meds.\nStay healthy!");
		//dialogues.Add (DOCTOR_DICK, "benis");
		//dialogues.Add (DOCTOR_DICK, "jee");
	}
	
}


