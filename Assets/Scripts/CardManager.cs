using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CardManager : MonoBehaviour
{
	public Transform target;
	[SerializeField]
	float cardSnapSpeed;
	public GameObject selfDeck;
	public CardType cardType;

	private void Start()
	{
		transform.position = target.position;
	}

	public void UpdateCardPos() 
    {
		Vector3 diff = target.position - transform.position;
		Vector3 direction = diff.normalized;
		transform.position += direction * Mathf.Pow(diff.magnitude, 1) * Time.deltaTime * cardSnapSpeed;
		transform.position = new Vector3(transform.position.x,transform.position.y,-1.0f);
		//transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
	}

    public void SetTarget(Transform tar)
    {
		target = tar;
    }
	public void ChangeSelfDeck(GameObject newDeck)
	{
		selfDeck = newDeck;
	}

}
