using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class cursorScript : MonoBehaviour
{
    Vector3 cursorPosition;

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

	public TileBase GetTileAt(Tilemap map) 
	{
		return map.GetTile(Vector3Int.FloorToInt( transform.position));
	}

	public void SetTileAt(Tilemap map, TileBase block) 
	{
		map.GetComponentInParent<Grid>().cellSize = new Vector3(1, 1, 0);
		map.SetTile(Vector3Int.FloorToInt( transform.position),null);
		
	}
}
