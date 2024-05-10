using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	cursorScript cursor;
	[SerializeField]
	float cardNum = 1;
	[SerializeField]
	List<CardManager> allCards = new List<CardManager>();
	[SerializeField]
	GameObject deck;


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
		cursor.ClickAndRelease();
		if (cursor.mouseBehaviour == cursorScript.MouseBehaviour.released) 
		{
			foreach (var card in allCards)
			{
				card.SetTarget(deck.transform);
			}
			cursor.mouseBehaviour = cursorScript.MouseBehaviour.hovering;
		}
		else if (cursor.mouseBehaviour == cursorScript.MouseBehaviour.dragging)
		{
			foreach (var card in allCards)
			{
				card.SetTarget(cursor.transform);
			}
		}
	}


}
