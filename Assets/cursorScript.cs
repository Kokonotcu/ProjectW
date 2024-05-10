using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour
{
    Vector3 cursorPosition;
    
	public void SetCursorPos()
	{
		cursorPosition = Input.mousePosition;
		cursorPosition.z = 10.0f;
		transform.position = Camera.main.ScreenToWorldPoint(cursorPosition);
	}

}
