using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class magmaEffect : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("character");

        var traps = GameObject.FindGameObjectsWithTag("Trap");

        foreach (var trap in traps)
        {
            if (Vector3.Distance(transform.position, trap.transform.position) <= 3.7f)
            {
                Destroy(trap);
            }
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= 3.7f)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        player.GetComponent<characterMovement>().setDead();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
