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

	//Mouse possessing this object
	Collider2D other;


	void Update()
    {
		CursorUpdate(out other);
		foreach (var card in allCards)
		{
			card.UpdateCardPos();
		}
    }

	void CursorUpdate(out Collider2D other) 
	{
		cursor.SetCursorPos();
		cursor.ClickAndRelease();
		cursor.Drag(out other);
	}


}
