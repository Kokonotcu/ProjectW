using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	cursorScript cursor;
	[SerializeField]
	InstantiateObjects ins;

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
		cursor.ClickAndRelease(out Collider2D other);
		if (cursor.mouseBehaviour == cursorScript.MouseBehaviour.released) 
		{
			int i = 0;
			foreach (var card in allCards)
			{
				card.SetTarget(allDecks[i].transform);
				i++;
			}
			cursor.mouseBehaviour = cursorScript.MouseBehaviour.hovering;
		}
		else if (cursor.mouseBehaviour == cursorScript.MouseBehaviour.dragging)
		{
			int i = 0;
			foreach (var card in allCards)
			{
				card.SetTarget(allDecks[i].transform);
				i++;
			}
			other.GetComponent<CardManager>().SetTarget(cursor.transform);
			//card.SetTarget();
		}
	}


}
