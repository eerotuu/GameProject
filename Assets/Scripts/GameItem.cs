using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameItem
{
	private string itemName;
	private string itemImage;

	public GameItem (string name, string imageName)
	{
		this.itemName = name;
		this.itemImage = imageName;
	}

	public string GetGameItem ()
	{
		return this.itemName;
	}

	public Sprite GetItemImage ()
	{
		return Resources.Load <Sprite> (this.itemImage);
	}
}


