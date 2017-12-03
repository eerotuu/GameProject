using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Npc
{
	public string name;
	public string message;
	public bool sells;
	public bool hasQuestion;

	public Npc (string name, string message)
	{
		this.name = name;
		this.message = message;
	}

	public Npc (string name, string message, bool sells, bool hasQuestion)
	{
		this.name = name;
		this.message = message;
		this.sells = sells;
		this.hasQuestion = hasQuestion;
	}


}


