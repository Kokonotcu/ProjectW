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
	List<InstantiateObjects> allInstances;

	Collider2D other, another;

	List<List<CardManager>> allCards = new List<List<CardManager>>() ;
	List<List<GameObject>> allDecks = new List<List<GameObject>>(); 

	private void Awake()
	{
		for (int i = 0; i < 3; i++)
		{
			allCards.Add( allInstances[i].GetReferenceToCards());
			allDecks.Add(allInstances[i].GetReferenceToDecks());
		}
		
	}

	void Update()
    {
		CursorUpdate();
		foreach (var cardList in allCards)
		{
			foreach (var card in cardList) 
			{
				card.UpdateCardPos();
			}
		}
    }

	void CursorUpdate() 
	{
		cursor.SetCursorPos();
		if (Input.GetMouseButtonDown(0))
		{
			cursor.SendRay(out Collider2D hit);
			another = hit;
			if (another != null && another.tag == "Cards")
			{
				another.gameObject.GetComponent<CardManager>().SetTarget(cursor.transform);
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			if (another != null && another.tag == "Cards")
			{
				var cm = another.GetComponent<CardManager>();
				if (cursor.collidingDeck != null && cursor.collidingDeck.gameObject != cm.selfDeck)
				{
					if (cursor.collidingDeck.tag == "Deck")
					{
						cm.SetTarget(cursor.collidingDeck.transform);
						cm.ChangeSelfDeck(cursor.collidingDeck.gameObject);
					}
					//If sent to Viewport
					else 
					{
						cm.SetTarget(cursor.collidingDeck.transform);
						cm.ChangeSelfDeck(cursor.collidingDeck.gameObject);
						SentToViewport(another);
					}
					//If sent to Viewport end
				}
				else
				{
					cm.SetTarget(cm.selfDeck.transform);
				}
			}
		}
		else
		{
			cursor.SendRay(out Collider2D hit);
			if (other != null && hit != null && other.tag == "Cards" && other.gameObject != hit.gameObject)
			{
				var trans = other.gameObject.transform;
				trans.localScale = new Vector3(1f, 1f, 1f);
				other.GetComponent<SpriteRenderer>().sortingOrder = 100;
			}
			
			if (hit != null && (hit.tag == "Cards"))
			{
				
				hit.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
				hit.GetComponent<SpriteRenderer>().sortingOrder = 200;
			}
			other = hit;

		}

	}

	public void SentToViewport(Collider2D sentObj) 
	{

	}

}
