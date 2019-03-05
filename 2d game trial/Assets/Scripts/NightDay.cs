using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NightDay : MonoBehaviour
{
    public Tilemap TilemapCo;
    public Tilemap CollCo;
    public float co = 0.4823529f;
    public float currentco = 1f;
    public float timeChange = 1f;


    // Start is called before the first frame update
    void Start()
    {

        TilemapCo.color = new Color(currentco, currentco, currentco);
        CollCo.color = new Color(currentco, currentco, currentco);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeChange)
        {
            if (currentco > co)
            {
                currentco -= 0.01f;
                TilemapCo.color = new Color(currentco, currentco, currentco);
                CollCo.color = new Color(currentco, currentco, currentco);
                timeChange = Time.time + 0.2f;
            }
            

        }
    }
}
