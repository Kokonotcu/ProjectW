using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static cursorScript;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	cursorScript cursor;
	[SerializeField]
	InstantiateObjects ins;
	[SerializeField]
	Tilemap tilemap;
	[SerializeField]
	TileBase denemetilebase;

	Collider2D other;

	List<CardManager> allCards;
	List<GameObject> allDecks;

	private void Awake()
	{
		allCards = ins.GetReferenceToCards();
		allDecks = ins.GetReferenceToDecks();
	}

	void Update()
    {
		CursorUpdate();
		foreach (var card in allCards)
		{
			card.UpdateCardPos();
		}
    }

	void CursorUpdate() 
	{
		cursor.SetCursorPos();
		if (Input.GetMouseButtonDown(0))
		{
			cursor.SendRay(out Collider2D hit);
			other = hit;
			if (other != null && other.tag == "Cards")
			{
				other.gameObject.GetComponent<CardManager>().SetTarget(cursor.transform);
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			if (other != null && other.tag == "Cards")
			{
				other.GetComponent<CardManager>().SetTarget(
					other.GetComponent<CardManager>().selfDeck.transform);
			}
			else if (other != null && other.tag == "Tile") 
			{
				Debug.Log(cursor.GetTileAt(tilemap));
				cursor.SetTileAt(tilemap,denemetilebase);
			}
		}
		else 
		{
			if (other != null && other.tag == "Cards")
			{
				other.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				other.GetComponent<SpriteRenderer>().sortingOrder = 1;
			}
			cursor.SendRay(out Collider2D hit);
			other = hit;
			if (hit != null && (hit.tag == "Cards")) 
			{
				hit.gameObject.transform.localScale += new Vector3(0.2f,0.2f,0.2f);
				other.GetComponent<SpriteRenderer>().sortingOrder = 2;
			}
		}


	}


}
