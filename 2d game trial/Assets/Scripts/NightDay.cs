using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NightDay : MonoBehaviour
{
    public Tilemap TilemapCo;
    private int Co = 255;
    private int x = 0;
    private int cox;
    
    // Start is called before the first frame update
    void Start()
    {
        
        TilemapCo.color = new Color(123, 123, 123);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
