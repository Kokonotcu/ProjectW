using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class cursorScript : MonoBehaviour
{
    Vector3 cursorPosition;
	public Collider2D collidingDeck;

	public void SetCursorPos()
	{
		cursorPosition = Input.mousePosition;
		cursorPosition.z = 10.0f;
		transform.position = Camera.main.ScreenToWorldPoint(cursorPosition);
	}

	public void SendRay(out Collider2D hit1)
	{
		Vector2 rayA = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
			Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(
			new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20)),
			Vector2.zero);
		hit1 = hit.collider;
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Deck" || collision.tag == "Viewport")
		{
			Debug.Log(collision.name);
			collidingDeck = collision;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		//if (collision.tag == "Deck")
		//{
		//	Debug.Log("null");
		//	collidingDeck = null;
		//}
	}

}
