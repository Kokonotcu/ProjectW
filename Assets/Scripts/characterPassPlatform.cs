using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterPassPlatform : MonoBehaviour
{
    private Collider2D charCollider;
    private bool charOnPlatform;

    // Start is called before the first frame update
    void Start()
    {
        charCollider = GetComponent<Collider2D>();
        
    }

    private void SetCharOnPlatform(Collider2D other, bool value)
    {
        var player = other.gameObject.GetComponent<characterMovement>();
        if(player != null)
        {
            charOnPlatform = value;
            Physics2D.IgnoreLayerCollision(8, 9, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SetCharOnPlatform(other.collider, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SetCharOnPlatform(other.collider, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(  charOnPlatform && Input.GetAxisRaw("Vertical")<0)
        {
            charCollider.enabled = false;
            StartCoroutine(EnableCollider());
        }

    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(1f);
        charCollider.enabled = true;
    }
}
