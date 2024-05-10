using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name + " triggered me");
        if (collision.gameObject == GameObject.Find("testobj"))
        {
            Camera.main.GetComponent<CameraBehaviour>().ProceedNextLevel();
        }
    }
}
