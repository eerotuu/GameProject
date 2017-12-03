using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory
{
	private List<GameItem> inventory;
	private GameItem currentItem;
	Image itemSlot0Image;
	Image itemSlot1Image;
	/*GameObject itemSlot0;
	GameObject itemSlot1;*/


	public Inventory ()
	{
		inventory = new List<GameItem> ();
	}

	public void AddItem (GameItem name)
	{
		if (inventory.Count < 2) {
			inventory.Add (name);
			Debug.Log ("Added " + name.GetGameItem () + " into inventory");
		}

	}

	public void RemoveItem (GameItem name)
	{
		inventory.Remove (name);
	}

	public void ListInventory ()
	{
		if (inventory.Count > 0) {
			itemSlot0Image = GameObject.Find ("ItemImage0").GetComponent<Image> ();
			itemSlot0Image.sprite = inventory [0].GetItemImage ();
			itemSlot0Image.enabled = true;

			if (inventory.Count > 1) {
				itemSlot1Image = GameObject.Find ("ItemImage1").GetComponent<Image> ();
				itemSlot1Image.sprite = inventory [1].GetItemImage ();
				itemSlot1Image.enabled = true;
			} else {
				itemSlot1Image.enabled = false;
			}
		} else {
			itemSlot0Image.enabled = false;
			itemSlot1Image.enabled = false;
		}



	}

	public void HideInventory ()
	{
		
	}

}


