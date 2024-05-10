using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    cursorScript cursor;

    void Update()
    {
        cursor.SetCursorPos();
        cursor.ClickAndRelease();
        cursor.Drag();
    }
}
