using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public bool isLockedButton;
	public bool notLockedButton;

	private  bool pressed;


	public void OnPointerUp (PointerEventData eventData)
	{
		pressed = false;

	}


	public void OnPointerDown (PointerEventData eventData)
	{
		pressed = true;
	}

	public bool getPressed ()
	{
		return pressed;
	}


}
