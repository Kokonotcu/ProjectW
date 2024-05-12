using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tileEffects : MonoBehaviour
{
    [SerializeField]
    private Transform tileCheck;
    [SerializeField]
    private Tilemap tmap;
    [SerializeField]
    private GameObject debgob;

    // Start is called before the first frame update
    void Start()
    {
        



    }

    //private TileBase GetTileInLocation(Tilemap map, Vector3Int position)
    //{
    //    Physics2D.OverlapCircle(tileCheck.position, 0.2f, groundLayer);
    //}

    // Update is called once per frame
    void Update()
    {
        Vector3Int currentPosition = Vector3Int.FloorToInt(tileCheck.transform.position);
        debgob.transform.position = currentPosition;


        var tile = tmap.GetTile(Vector3Int.FloorToInt(tileCheck.transform.position));

    }
}
