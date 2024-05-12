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
    public int radius;


    public List<Tile> hellTiles;
    public List<Tile> sandTiles;
    public List<Tile> IceTiles;

    public enum CardType
    {
        Hell,
        Sand,
        Ice
    }

    // Function to change tiles within a given radius
    public void ChangeTilesWithinRadius(Vector3Int position, CardType type)
    {
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

                    // If the tile is a rock tile, change it to magma tile
                    if (baseTile != null)
                    {
                        int index = int.Parse(baseTile.name[(baseTile.name.LastIndexOf('_') + 1)..]);
                        switch (type)
                        {
                            case CardType.Hell:
                                tileMapBase.SetTile(currentPosition, hellTiles[index]);
                                break;
                            case CardType.Sand:
                                tileMapBase.SetTile(currentPosition, sandTiles[index]);
                                break;
                            case CardType.Ice:
                                tileMapBase.SetTile(currentPosition, IceTiles[index]);
                                break;
                        }
                    }
                    if (colliderTile != null)
                    {
                        int index = int.Parse(colliderTile.name[(colliderTile.name.LastIndexOf('_') + 1)..]);
                        switch (type)
                        {
                            case CardType.Hell:

                                collidersTileMap.SetTile(currentPosition, hellTiles[index]);
                                break;
                            case CardType.Sand:
                                collidersTileMap.SetTile(currentPosition, sandTiles[index]);

                                break;
                            case CardType.Ice:
                                collidersTileMap.SetTile(currentPosition, IceTiles[index]);

                                break;
                        }
                    }
                    if (bgTile != null)
                    {
                        int index = int.Parse(bgTile.name[(bgTile.name.LastIndexOf('_') + 1)..]);
                        switch (type)
                        {
                            case CardType.Hell:

                                bgTileMap.SetTile(currentPosition, hellTiles[index]);
                                break;
                            case CardType.Sand:

                                bgTileMap.SetTile(currentPosition, sandTiles[index]);
                                break;
                            case CardType.Ice:
                                bgTileMap.SetTile(currentPosition, IceTiles[index]);

                                break;
                        }
                    }
                    if (bgTile2 != null)
                    {
                        int index = int.Parse(bgTile2.name[(bgTile2.name.LastIndexOf('_') + 1)..]);
                        switch (type)
                        {
                            case CardType.Hell:

                                bg2TileMap.SetTile(currentPosition, hellTiles[index]);
                                break;
                            case CardType.Sand:
                                bg2TileMap.SetTile(currentPosition, sandTiles[index]);

                                break;
                            case CardType.Ice:
                                bg2TileMap.SetTile(currentPosition, IceTiles[index]);

                                break;
                        }
                    }
                }
            }
        }
    }
}
