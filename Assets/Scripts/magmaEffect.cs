using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magmaEffect : MonoBehaviour
{
    private bool canKillPlayer = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            player = other.gameObject;
            canKillPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            canKillPlayer = false;
        }
    }

    private void KillPlayer()
    {
        if(canKillPlayer)
        {
            player.GetComponent<characterMovement>().setDead();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
