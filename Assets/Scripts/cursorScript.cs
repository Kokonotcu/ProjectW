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

	Vector3 diffBetweenMouseNCard;

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

	public void ClickAndRelease() 
	{
		if (Input.GetMouseButtonDown(0) && other!= null && other.gameObject.tag == "Cards")
		{
			mouseBehaviour = MouseBehaviour.dragging;
			diffBetweenMouseNCard = transform.position - other.transform.position;
			Debug.Log('s');
		}
		else if (Input.GetMouseButtonUp(0)) 
		{
			mouseBehaviour = MouseBehaviour.released;
		}
		else 
		{
			Debug.Log('a');
		}
	}

	public void Drag()
	{
		if (mouseBehaviour == MouseBehaviour.dragging)
		{
			other.transform.position = transform.position - diffBetweenMouseNCard;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		other = collision.collider;
		mouseBehaviour = MouseBehaviour.hovering;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		other = null;
		mouseBehaviour = MouseBehaviour.released;
	}
}
