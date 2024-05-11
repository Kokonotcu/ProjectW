using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGBehaiour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = Camera.main.transform.position + new Vector3(0,0,10);
    }
}
