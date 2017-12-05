using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Pointer controller.
/// </summary>
public class PointerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public bool isLockedButton;
	public bool notLockedButton;

	private  bool pressed;

	/// <summary>
	/// Raises the pointer up event.
	/// </summary>
	/// <param name="eventData">Event data.</param>
	public void OnPointerUp (PointerEventData eventData)
	{
		pressed = false;

	}

	/// <summary>
	/// Raises the pointer down event.
	/// </summary>
	/// <param name="eventData">Event data.</param>
	public void OnPointerDown (PointerEventData eventData)
	{
		pressed = true;
	}

	/// <summary>
	/// Gets the pressed.
	/// </summary>
	/// <returns><c>true</c>, if pressed was gotten, <c>false</c> otherwise.</returns>
	public bool getPressed ()
	{
		return pressed;
	}
		
}
