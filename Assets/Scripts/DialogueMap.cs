using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueMap
{
	public const string DOCTOR_DICK = "Doctor Dick";
	public const string DOCTOR_NICK = "Doctor Nick";
	public const string NURSE_NANCY = "Nurse Nancy";
	public static string BOB_BURGER = "Bob Burger";
	public const string VEGANVILLE_MAFIA = "VeganVille Mafia";
	public const string BAD_LUCK_BRIAN = "Bad Luck Brian";

	public static string DEFAULT = "default";
	public static string STEP_1 = "STEP1";
	public static string STEP_2 = "STEP2";
	public static string STEP_3 = "STEP3";
	public static string STEP_4 = "STEP4";

	public const string Le_AFFAME = "Le Affame";
	public const string BRGCLUB = "BRGCLUB";
	public const string TOUGH = "Tough";
	public const string SHISH = "Shish";
	public const string THE_BOGO = "The Bögö";
	static bool run;



	public static Dictionary<string, string> dialogues = new Dictionary<string, string> ();

	public DialogueMap ()
	{
		if (!run) {
			AddDialogues ();
			run = true;
		}

	}



	public string GetDialogue (string name)
	{	
		return dialogues [name];	
	}

	void AddDialogues ()
	{
		//DOCTOR DICK
		dialogues.Add (DOCTOR_DICK + DEFAULT, "So... Bobby Ulk. I'm worried about your bulking habit. I need you to start healthy diet and stop this fast food madness.\n\nAre you OK with this?");
		dialogues.Add (DOCTOR_DICK + STEP_1, "Thats good you are changing your habits!\nGo fetch your meds from Nurse Nancy and you are free to go.");

		//DOCTOR NICK
		dialogues.Add (DOCTOR_NICK + DEFAULT, "So... Bobby Ulk. I'm worried about your bulking habit. I need you to start healthy diet and stop this fast food madness.\n\nAre you OK with this?");

		//NURSE NANCY
		dialogues.Add (NURSE_NANCY + DEFAULT, "Hi!\nAre you here for your meds?");
		dialogues.Add (NURSE_NANCY + STEP_1, "Go talk to Doctor Dick first");
		dialogues.Add (NURSE_NANCY + STEP_2, "Alright, here is your meds.\nStay healthy!");
		dialogues.Add (NURSE_NANCY + STEP_3, "You already got your meds junkie!");

		//VEGANVILLE MAFIA
		dialogues.Add (VEGANVILLE_MAFIA + DEFAULT, "Hey ever killed a man before?");
		dialogues.Add (VEGANVILLE_MAFIA + STEP_1, "I need you to kill a witness who currently lies in a hospital. Take this poison and end his life.\nWe will pay you 1000$");
		dialogues.Add (VEGANVILLE_MAFIA + STEP_2, "Is he... sleeping yet?");
		dialogues.Add (VEGANVILLE_MAFIA + STEP_3, "Good Job! Here is your reward, 1000$ as promised.");
		dialogues.Add (VEGANVILLE_MAFIA + STEP_4, "...");

		dialogues.Add (BAD_LUCK_BRIAN + DEFAULT, "...");
		dialogues.Add (BAD_LUCK_BRIAN + STEP_1, "...\n\nInject poison?");

		dialogues.Add (BRGCLUB + DEFAULT, "Hello and welcome to everyones favourite BRGCLUB!\nWould you like a MegaBurger for 17$?");
		dialogues.Add (BRGCLUB + STEP_1, "Enjoy!");
		dialogues.Add (BRGCLUB + STEP_2, "You need to pay you know...");

		dialogues.Add (TOUGH + DEFAULT, "Hello and welcome to Tough-restaurant!\nTodays HappyMeal for only 12$!");
		dialogues.Add (TOUGH + STEP_1, "Enjoy!");
		dialogues.Add (TOUGH + STEP_2, "You need to pay you know...");

		dialogues.Add (Le_AFFAME + DEFAULT, "Good day sir!\nMay I interest you in a French cuisine for only 55$?");
		dialogues.Add (Le_AFFAME + STEP_1, "Enjoy!");
		dialogues.Add (Le_AFFAME + STEP_2, "This is no place for poor hobos.");
	
		dialogues.Add (THE_BOGO + DEFAULT, "Hello!\nWould you like some kebab for 7$?");
		dialogues.Add (THE_BOGO + STEP_1, "Enjoy!");
		dialogues.Add (THE_BOGO + STEP_2, "NO KEBABO FOR YOU!!!");

		dialogues.Add (SHISH + DEFAULT, "Hellooyouuwannashiish 5 dollah?");
		dialogues.Add (SHISH + STEP_1, "Heere youu uno shiish.");
		dialogues.Add (SHISH + STEP_2, "NO MONEY NO SHISH!!!");



	}
	
}


