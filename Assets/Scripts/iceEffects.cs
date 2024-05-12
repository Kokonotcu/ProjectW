using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceEffects : MonoBehaviour
{
    private float originalSpeed, originalJumpForce;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            originalSpeed = other.gameObject.GetComponent<characterMovement>().speed;
            originalJumpForce = other.gameObject.GetComponent<characterMovement>().jumpForce;
            other.gameObject.GetComponent<characterMovement>().speed = 30;
            other.gameObject.GetComponent<characterMovement>().jumpForce = 70;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            other.gameObject.GetComponent<characterMovement>().speed = originalSpeed;
            other.gameObject.GetComponent<characterMovement>().jumpForce = originalJumpForce;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
