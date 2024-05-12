using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Tilemaps;
using static cursorScript;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	cursorScript cursor;
	[SerializeField]
	List<InstantiateObjects> allInstances;
	int TotalCardsInScene = 0;
	public Vector2 spawnOffset = new Vector2(0,-2.0f);

	Collider2D other, another;

	List<List<CardManager>> allCards = new List<List<CardManager>>() ;
	List<List<GameObject>> allDecks = new List<List<GameObject>>(); 

	private void Awake()
	{
		for (int i = 0; i < 3; i++)
		{
			allCards.Add( allInstances[i].GetReferenceToCards());
			allDecks.Add(allInstances[i].GetReferenceToDecks());
			TotalCardsInScene +=  allCards[i].Count;
		}
		
	}

	void Update()
    {
		CursorUpdate();
		//update deck pos old fashioned
		//for (int i = 0;i < 3;i++) 
		//{
		//	allInstances[i].UpdateDeckPos();
		//}
		UpdateDeckPos();
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
			if (another != null && another.CompareTag("Cards"))
			{
				var cm = another.GetComponent<CardManager>();
				if (cursor.collidingDeck != null && cursor.collidingDeck.gameObject != cm.selfDeck)
				{
					//if (cursor.collidingDeck.tag == "Deck")
					//{
					//	cm.SetTarget(cursor.collidingDeck.transform);
					//	cm.ChangeSelfDeck(cursor.collidingDeck.gameObject);
					//}
					//If sent to Viewport
					//else 
					//{
						cm.SetTarget(cursor.collidingDeck.transform);
						cm.ChangeSelfDeck(cursor.collidingDeck.gameObject);
						SentToViewport(another);
					//}
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
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10f);
        

		switch(sentObj.gameObject.GetComponent<CardManager>().cardType)
		{
			case CardType.Hell:
                GameObject.Find("TileMapController").GetComponent<TileMapController>().
					ChangeTilesWithinRadius(new Vector3Int(Mathf.FloorToInt(worldPosition.x * 2), Mathf.FloorToInt(worldPosition.y * 2), Mathf.FloorToInt(worldPosition.z)), CardType.Hell);
                break;

			case CardType.Ice:
                GameObject.Find("TileMapController").GetComponent<TileMapController>().
					ChangeTilesWithinRadius(new Vector3Int(Mathf.FloorToInt(worldPosition.x * 2), Mathf.FloorToInt(worldPosition.y * 2), Mathf.FloorToInt(worldPosition.z)), CardType.Ice);
				break;

			case CardType.Sand:
                GameObject.Find("TileMapController").GetComponent<TileMapController>().
					ChangeTilesWithinRadius(new Vector3Int(Mathf.FloorToInt(worldPosition.x * 2), Mathf.FloorToInt(worldPosition.y * 2), Mathf.FloorToInt(worldPosition.z)), CardType.Sand);
				break;
        }

		DestroySafely(sentObj.gameObject);

		CameraBehaviour cum = Camera.main.GetComponent<CameraBehaviour>();

		cum.LevelCards[cum.CurrentLevelIndex].Remove(sentObj.gameObject.GetComponent<CardManager>().cardType);
        //ResetCards();
        //SpawnSafely(CardType.Sand);
        //SpawnSafely(CardType.Hell);
        //SpawnSafely(CardType.Ice);
    }

	public void DestroySafely(GameObject sentObj) 
	{
		int listNum = 0;
		int cardIndex = 0;
		foreach (var cardList in allCards)
		{
			var cm = sentObj.GetComponent<CardManager>();
			if (cardList.Contains(cm))
			{
				cardIndex = cardList.IndexOf(cm);
				cardList.Remove(cm);
				Destroy(cm.gameObject);
				break;
			}
			listNum++;
		}

		allInstances[listNum].cardNum -= 1;
		GameObject deck = allDecks[listNum][cardIndex];
		allDecks[listNum].Remove(deck);
		Destroy(deck);
		TotalCardsInScene--;
	}

	public void ResetCards() 
	{
		foreach (var cardList in allCards)
		{
			for (int i = 0; i<cardList.Count; i++)
			{
				DestroySafely(cardList[i].gameObject);
			}
		}
		TotalCardsInScene = 0;
	}

	public GameObject SpawnSafely(CardType type) 
	{
		GameObject card = allInstances[(int)type].SpawnNewCard();
		allInstances[(int)type].cardNum++;
		TotalCardsInScene++;
		//allCards[]
		//Instantiate();

		return card;
	}

	public void UpdateDeckPos() 
	{
		int i = 0;
		foreach (var deckLists in allDecks)
		{
			foreach (var deck in deckLists)
			{
				deck.transform.position = new Vector3(
				(Camera.main.transform.position.x -10.0f) + 20.0f /(TotalCardsInScene+1)*(i+1),
				Camera.main.transform.position.y + spawnOffset.y,
				0.0f);

				i++;
			}
		}
	}
}
