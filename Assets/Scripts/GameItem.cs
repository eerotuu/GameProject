using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for GameItems.
/// </summary>
public class GameItem
{
	private string itemName;
	private string itemImage;

	/// <summary>
	/// Initializes a new instance of the <see cref="GameItem"/> class.
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="imageName">Image name.</param>
	public GameItem (string name, string imageName)
	{
		this.itemName = name;
		this.itemImage = imageName;
	}

	/// <summary>
	/// Gets the game item name.
	/// </summary>
	/// <returns>The game item.</returns>
	public string GetGameItem ()
	{
		return this.itemName;
	}

	/// <summary>
	/// Gets the item image.
	/// </summary>
	/// <returns>The item image.</returns>
	public Sprite GetItemImage ()
	{
		return Resources.Load <Sprite> (this.itemImage);
	}
}


