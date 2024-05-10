using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    float cardSnapSpeed;


	void Start()
    {
        transform.position = target.position;
    }

    public void UpdateCardPos() 
    {
        Vector3 diff = target.position - transform.position;
        Vector3 direction = diff.normalized;
        transform.position += direction * Mathf.Pow(diff.magnitude, 2) * Time.deltaTime * cardSnapSpeed ;
    }
}
