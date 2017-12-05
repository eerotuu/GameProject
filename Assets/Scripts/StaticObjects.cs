using System;
using UnityEngine;


public class StaticObjects
{
	public static bool OBJECTIVE_VEGAN_BEATED;
	public static bool GOT_MEDS;
	public static bool TALKED_TO_NANCY;
	public static bool FREE_CHEESEBURGER;
	public static bool FREE_CHEESEBURGER_GAINED;

	public static int QUEST_FAKEDOCTOR = 0;

	public static string DOCTOR_DICK_STATUS = DialogueMap.DEFAULT;
	public static bool DOCTOR_DICK_HASQUESTION = true;

	public static string NURSE_NANCY_STATUS = DialogueMap.DEFAULT;
	public static bool NURSE_NANCY_HASQUESTION = true;

	public static string MAFIA_STATUS = DialogueMap.DEFAULT;
	public static bool MAFIA_HASQUESTION = true;

	public static bool OBJECTIVE_FAKE_DOCTOR_HASQUESTION = false;
	public static string OBJECTIVE_FAKE_DOCTOR_STATUS = DialogueMap.DEFAULT;

	static public void Reset ()
	{
		OBJECTIVE_VEGAN_BEATED = false;
		GOT_MEDS = false;
		TALKED_TO_NANCY = false;
		FREE_CHEESEBURGER = false;
		FREE_CHEESEBURGER_GAINED = false;

		QUEST_FAKEDOCTOR = 0;

		DOCTOR_DICK_STATUS = DialogueMap.DEFAULT;
		DOCTOR_DICK_HASQUESTION = true;

		NURSE_NANCY_STATUS = DialogueMap.DEFAULT;
		NURSE_NANCY_HASQUESTION = true;

		MAFIA_STATUS = DialogueMap.DEFAULT;
		MAFIA_HASQUESTION = true;

		OBJECTIVE_FAKE_DOCTOR_HASQUESTION = false;
		OBJECTIVE_FAKE_DOCTOR_STATUS = DialogueMap.DEFAULT;
		
	}

}
