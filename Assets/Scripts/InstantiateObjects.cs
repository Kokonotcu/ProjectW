using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
	public Vector2 spawnOffset;
	public float deckOffset;

	[SerializeField]
	GameObject cardPrefab;
	[SerializeField]
	GameObject deckPrefab;
	[SerializeField]
	List<CardManager> allCards = new List<CardManager>();
	[SerializeField]
	List<GameObject> allDecks = new List<GameObject>();


	public float cardNum = 1;

	private void Awake()
	{
		for (int i = 0; i < cardNum; i++)
		{
			allCards.Add(Instantiate(cardPrefab).GetComponent<CardManager>());
			allDecks.Add(Instantiate(deckPrefab));
		}

		for (int i = 0; i < cardNum; i++)
		{
			allDecks[i].transform.position = new Vector3(
				i*(18.0f)/cardNum + Camera.main.transform.position.x - 7.5f + spawnOffset.x+ deckOffset,
				Camera.main.transform.position.y - 3.0f+ spawnOffset.y, 
				0.0f);

			allCards[i].SetTarget(allDecks[i].transform);
			allCards[i].selfDeck = allDecks[i];
		}
	}

	public List<CardManager> GetReferenceToCards()
	{
		return allCards;
	}

	public List<GameObject> GetReferenceToDecks()
	{
		return allDecks;
	}

	public void UpdateDeckPos()
	{
		for (int i = 0; i < cardNum; i++)
		{
			allDecks[i].transform.position = new Vector3(
				i * (18.0f) / cardNum + Camera.main.transform.position.x - 7.5f + spawnOffset.x + deckOffset,
				Camera.main.transform.position.y - 3.0f + spawnOffset.y,
				0.0f);
		}
	}

	public GameObject SpawnNewCard() 
	{
		var card = Instantiate(cardPrefab).GetComponent<CardManager>();
		var deck = Instantiate(deckPrefab);
		allCards.Add(card);
		allDecks.Add(deck);

		card.SetTarget(deck.transform);
		card.selfDeck = deck;

		return card.gameObject;
	}

}
