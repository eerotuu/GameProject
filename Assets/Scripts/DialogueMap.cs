using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueMap
{
	public static string DOCTOR_DICK = "Doctor Dick";
	public static string NURSE_NANCY = "Nurse Nancy";
	public static string BOB_BURGER = "Bob Burger";
	public const string VEGANVILLE_MAFIA = "VeganVille Mafia";

	public static string DEFAULT = "default";
	public static string STEP_1 = "STEP1";
	public static string STEP_2 = "STEP2";
	public static string STEP_3 = "STEP3";



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

		dialogues.Add (VEGANVILLE_MAFIA + DEFAULT, "Hey ever killed a man before?");
		dialogues.Add (VEGANVILLE_MAFIA + STEP_1, "I need you to kill a witness who currently lies in a hospital. Take this poison and end his life.\nWe will pay you 1000$");
		dialogues.Add (VEGANVILLE_MAFIA + STEP_2, "");
	}
	
}


