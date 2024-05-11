using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
	[SerializeField]
	GameObject cardPrefab;
	[SerializeField]
	GameObject deckPrefab;
	[SerializeField]
	List<CardManager> allCards = new List<CardManager>();
	[SerializeField]
	List<GameObject> allDecks = new List<GameObject>();
	[SerializeField]
	float cardNum = 1;

	private void Awake()
	{
		for (int i = 0; i < cardNum; i++)
		{
			allCards.Add(Instantiate(cardPrefab).GetComponent<CardManager>());
			allDecks.Add(Instantiate(deckPrefab));
		}

		for (int i = 0; i < cardNum; i++)
		{
			Debug.Log(allDecks[i]);

			allDecks[i].transform.position = new Vector3(
				i*(10.0f)/cardNum + Camera.main.transform.position.x-5.0f,
				Camera.main.transform.position.y - 2.0f, 
				0.0f);

			allCards[i].SetTarget(allCards[i].transform);
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

}
