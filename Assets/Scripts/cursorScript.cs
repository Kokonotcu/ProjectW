using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour
{
    Vector3 cursorPosition;
	Collider2D collision, other;
	Transform otherTransform;
	MouseBehaviour mouseBehaviour;

	public enum MouseBehaviour 
	{
		hovering,
		dragging,
		released
	}

	private void Awake()
	{
		collision = GetComponent<Collider2D>();
	}

	public void SetCursorPos()
	{
		cursorPosition = Input.mousePosition;
		cursorPosition.z = 10.0f;
		transform.position = Camera.main.ScreenToWorldPoint(cursorPosition);
	}

	public void ClickAndDrag() 
	{
		if (Input.GetMouseButtonDown(0))
		{
			mouseBehaviour = MouseBehaviour.dragging;
			other.gameObject.tag = "Cards";
			Debug.Log('s');
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		other = collision.otherCollider;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		other = null;
	}
}
