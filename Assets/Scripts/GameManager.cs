using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	cursorScript cursor;

	//Mouse possessing this object
	Collider2D other;

	void Update()
    {
        cursor.SetCursorPos();
		cursor.ClickAndRelease();
		cursor.Drag(out other);
    }
}
