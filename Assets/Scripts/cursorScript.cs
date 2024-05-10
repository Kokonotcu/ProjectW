using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour
{
    Vector3 cursorPosition;
	Collider2D other;
	public MouseBehaviour mouseBehaviour;

	public enum MouseBehaviour 
	{
		hovering,
		dragging,
		released
	}

	public void SetCursorPos()
	{
		cursorPosition = Input.mousePosition;
		cursorPosition.z = 10.0f;
		transform.position = Camera.main.ScreenToWorldPoint(cursorPosition);
	}

	public void ClickAndRelease() 
	{
		if (Input.GetMouseButton(0) && 
			other != null &&
			other.gameObject.tag == "Cards")
		{
			mouseBehaviour = MouseBehaviour.dragging;
		}
		else if ((Input.GetMouseButtonUp(0))) 
		{
			mouseBehaviour = MouseBehaviour.released;
			other = null;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		other = collision;
		mouseBehaviour = MouseBehaviour.hovering;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
	}
}
