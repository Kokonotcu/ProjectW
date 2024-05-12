using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapController : MonoBehaviour
{
    public Tilemap tileMapBase;
    public Tilemap collidersTileMap;
    public Tilemap bgTileMap;
    public Tilemap bg2TileMap;
    public Tilemap climbTileMap;
    public Tilemap deathTileMap;
    public int radius;


    public List<Tile> hellTiles;
    public List<Tile> sandTiles;
    public List<Tile> IceTiles;

    public GameObject HellParticle;
    public GameObject IceParticle;
    public GameObject SandParticle;

    public GameObject HellArea;
    public GameObject IceArea;
    public GameObject SandArea;


    public List<GameObject> Scene1 = new List<GameObject>();
    public List<GameObject> Scene2 = new List<GameObject>();
    public List<GameObject> Scene3 = new List<GameObject>();
    public List<GameObject> Scene4 = new List<GameObject>();

    public int index;
    public int index2;
    public int index3;
    public int index4;

    public AudioClip hellClip;
    public AudioClip sandClip;
    public AudioClip iceClip;
    public AudioSource selfSource;

    public void Start()
    {
        selfSource = gameObject.GetComponent<AudioSource>(); 
    }

    public IEnumerator RunScenes(float delayTime)
    {
        //Wait for the specified delay time before continuing.

        switch (Camera.main.GetComponent<CameraBehaviour>().CurrentLevelIndex)
        {
            case 7:
                for (int i = 0; i < Scene1.Count; i++)
                {
                    ChangeTilesWithinRadius(new Vector3Int(Mathf.FloorToInt(Scene1[i].transform.position.x * 2), Mathf.FloorToInt(Scene1[i].transform.position.y * 2), Mathf.FloorToInt(Scene1[i].transform.position.z)), 
                        (CardType)Random.Range(0, 3), true);
                    yield return new WaitForSeconds(delayTime);
                }
                break;
            case 8:
                for (int i = 0; i < Scene2.Count; i++)
                {
                    ChangeTilesWithinRadius(new Vector3Int(Mathf.FloorToInt(Scene2[i].transform.position.x * 2), Mathf.FloorToInt(Scene2[i].transform.position.y * 2), Mathf.FloorToInt(Scene2[i].transform.position.z)), 
                        (CardType)Random.Range(0, 3), true);
                    yield return new WaitForSeconds(delayTime);
                }
                break;
            case 9:
                for (int i = 0; i < Scene3.Count; i++)
                {
                    ChangeTilesWithinRadius(new Vector3Int(Mathf.FloorToInt(Scene3[i].transform.position.x * 2), Mathf.FloorToInt(Scene3[i].transform.position.y * 2), Mathf.FloorToInt(Scene3[i].transform.position.z)), 
                        (CardType)Random.Range(0, 3), true);
                    yield return new WaitForSeconds(delayTime);
                }
                break;
            case 10:
                for (int i = 0; i < Scene4.Count; i++)
                {
                    ChangeTilesWithinRadius(new Vector3Int(Mathf.FloorToInt(Scene4[i].transform.position.x * 2), Mathf.FloorToInt(Scene4[i].transform.position.y * 2), Mathf.FloorToInt(Scene4[i].transform.position.z)), 
                        (CardType)Random.Range(0,1), true);
                    yield return new WaitForSeconds(delayTime);
                }

                break;
        }

        //Do the action after the delay time has finished.
    }

    // Function to change tiles within a given radius
    public void ChangeTilesWithinRadius(Vector3Int position, CardType type, bool isVisual = false)
    {
        if (!isVisual)
        {
            switch (type)
            {
                case CardType.Hell:
                    Instantiate(HellArea, position / 2, new Quaternion(), null);
                    selfSource.clip = hellClip;
                    selfSource.Play();
                    break;

                case CardType.Sand:
                    Instantiate(SandArea, position / 2, new Quaternion(), null);
                    selfSource.clip = sandClip;
                    selfSource.Play();
                    break;

                case CardType.Ice:
                    Instantiate(IceArea, position / 2, new Quaternion(), null);
                    selfSource.clip = iceClip;
                    selfSource.Play();
                    break;

            }
        }


        for (int x = -radius; x <= radius; x++)
        {
            for (int y = -radius; y <= radius; y++)
            {
                Vector3Int currentPosition = new Vector3Int(position.x + x, position.y + y, position.z);

                // Check if the tile is within the specified radius
                if (Vector3Int.Distance(currentPosition, position) <= radius)
                {
                    TileBase baseTile       = tileMapBase.GetTile(currentPosition);
                    TileBase colliderTile   = collidersTileMap.GetTile(currentPosition);
                    TileBase bgTile         = bgTileMap.GetTile(currentPosition);
                    TileBase bgTile2        = bg2TileMap.GetTile(currentPosition);
                    TileBase deathTile      = deathTileMap.GetTile(currentPosition);
                    TileBase climbTile      = climbTileMap.GetTile(currentPosition);

                    // If the tile is a rock tile, change it to magma tile
                    if (baseTile != null)
                    {
                        Debug.Log(baseTile.name);
                        int index = int.Parse(baseTile.name[(baseTile.name.LastIndexOf('_') + 1)..]);
                        switch (type)
                        {
                            case CardType.Hell:
                                tileMapBase.SetTile(currentPosition, hellTiles[index]);
                                Instantiate(HellParticle, currentPosition / 2, new Quaternion(), null);

                                break;
                            case CardType.Sand:
                                tileMapBase.SetTile(currentPosition, sandTiles[index]);
                                Instantiate(SandParticle, currentPosition / 2, new Quaternion(), null);

                                break;
                            case CardType.Ice:
                                tileMapBase.SetTile(currentPosition, IceTiles[index]);
                                Instantiate(IceParticle, currentPosition / 2, new Quaternion(), null);

                                break;
                        }
                    }
                    if (colliderTile != null)
                    {
                        Debug.Log(colliderTile.name);
                        int index = int.Parse(colliderTile.name[(colliderTile.name.LastIndexOf('_') + 1)..]);
                        switch (type)
                        {
                            case CardType.Hell:
                                Instantiate(HellParticle, currentPosition / 2, new Quaternion(), null);

                                collidersTileMap.SetTile(currentPosition, hellTiles[index]);
                                break;
                            case CardType.Sand:
                                collidersTileMap.SetTile(currentPosition, sandTiles[index]);
                                Instantiate(SandParticle, currentPosition / 2, new Quaternion(), null);

                                break;
                            case CardType.Ice:
                                collidersTileMap.SetTile(currentPosition, IceTiles[index]);
                                Instantiate(IceParticle, currentPosition / 2, new Quaternion(), null);

                                break;
                        }
                    }
                    if (bgTile != null)
                    {
                        int index = int.Parse(bgTile.name[(bgTile.name.LastIndexOf('_') + 1)..]);
                        switch (type)
                        {
                            case CardType.Hell:
                                Instantiate(HellParticle, currentPosition / 2, new Quaternion(), null);

                                bgTileMap.SetTile(currentPosition, hellTiles[index]);
                                break;
                            case CardType.Sand:
                                Instantiate(SandParticle, currentPosition / 2, new Quaternion(), null);

                                bgTileMap.SetTile(currentPosition, sandTiles[index]);
                                break;
                            case CardType.Ice:
                                bgTileMap.SetTile(currentPosition, IceTiles[index]);
                                Instantiate(IceParticle, currentPosition / 2, new Quaternion(), null);

                                break;
                        }
                    }
                    if (bgTile2 != null)
                    {
                        int index = int.Parse(bgTile2.name[(bgTile2.name.LastIndexOf('_') + 1)..]);
                        switch (type)
                        {
                            case CardType.Hell:
                                Instantiate(HellParticle, currentPosition / 2, new Quaternion(), null);

                                bg2TileMap.SetTile(currentPosition, hellTiles[index]);
                                break;
                            case CardType.Sand:
                                bg2TileMap.SetTile(currentPosition, sandTiles[index]);
                                Instantiate(SandParticle, currentPosition / 2, new Quaternion(), null);

                                break;
                            case CardType.Ice:
                                bg2TileMap.SetTile(currentPosition, IceTiles[index]);
                                Instantiate(IceParticle, currentPosition / 2, new Quaternion(), null);

                                break;
                        }
                    }
                    if (deathTile != null)
                    {
                        int index = int.Parse(deathTile.name[(deathTile.name.LastIndexOf('_') + 1)..]);
                        switch (type)
                        {
                            case CardType.Hell:
                                Instantiate(HellParticle, currentPosition / 2, new Quaternion(), null);
                                deathTileMap.SetTile(currentPosition, hellTiles[index]);
                                break;

                            case CardType.Sand:
                                deathTileMap.SetTile(currentPosition, null);
                                deathTileMap.GetComponent<TilemapCollider2D>().usedByComposite = false;
                                deathTileMap.GetComponent<TilemapCollider2D>().usedByComposite = true;
                                tileMapBase.SetTile(currentPosition, sandTiles[index]);
                                Instantiate(SandParticle, currentPosition / 2, new Quaternion(), null);
                                break;

                            case CardType.Ice:
                                deathTileMap.SetTile(currentPosition, null);
                                deathTileMap.GetComponent<TilemapCollider2D>().usedByComposite = false;
                                deathTileMap.GetComponent<TilemapCollider2D>().usedByComposite = true;
                                tileMapBase.SetTile(currentPosition, IceTiles[index]);
                                Instantiate(IceParticle, currentPosition / 2, new Quaternion(), null);
                                break;
                        }
                    }
                    if (climbTile != null)
                    {
                        int index = int.Parse(climbTile.name[(climbTile.name.LastIndexOf('_') + 1)..]);
                        switch (type)
                        {
                            case CardType.Hell:
                                Instantiate(HellParticle, currentPosition / 2, new Quaternion(), null);

                                climbTileMap.SetTile(currentPosition, hellTiles[index]);
                                break;
                            case CardType.Sand:
                                climbTileMap.SetTile(currentPosition, sandTiles[index]);
                                Instantiate(SandParticle, currentPosition / 2, new Quaternion(), null);

                                break;
                            case CardType.Ice:
                                climbTileMap.SetTile(currentPosition, IceTiles[index]);
                                Instantiate(IceParticle, currentPosition / 2, new Quaternion(), null);

                                break;
                        }
                    }
                }
            }
        }
    }
}

public enum CardType
{
    Sand,
    Hell,
    Ice
}