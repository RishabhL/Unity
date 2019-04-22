using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTiles : MonoBehaviour
{
    public Tilemap Terrain;
    public Tile[] Tiles;
    private int x;
    private int y;
    private int i;


    Vector3Int xy;
    // Start is called before the first frame update
    void Start()
    {
        /*
        for (x = -50; x <= 50; x++)
        {
            for (y = -50; y <= 50; y++)
            {
                xy = new Vector3Int(x, y, 1);
                Terrain.SetTile(xy, Tiles[0]);

            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
