using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDownScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerExitHandler {
	public bool isDown = false;
	public bool isExit = false;
	public bool isUp = false;
	public void OnPointerDown (PointerEventData eventData)
	{
		isDown = true;
		isExit = false;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		isDown = false;
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		isDown = false;
		isExit = true;
	}

	public bool ButtonIsDown() {
		return this.isDown;
	}
	public bool ButtonIsExit() {
		return this.isExit;
	}
}
