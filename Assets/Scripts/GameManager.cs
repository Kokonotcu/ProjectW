using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static cursorScript;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	cursorScript cursor;
	[SerializeField]
	InstantiateObjects ins;

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
			Debug.Log("a");
		}
		else if (Input.GetMouseButtonUp(0)) 
		{
			if (other != null) 
			{
				other.GetComponent<CardManager>().SetTarget(
					other.GetComponent<CardManager>().selfDeck.transform);
			}
		}
	}


}
