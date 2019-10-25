using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NightDay : MonoBehaviour
{
    public Tilemap TilemapCo;
    public Tilemap CollCo;
    public float co = 0.4800005f;
    public float currentco = 1f;
    public float timeChange = 1f;
    public bool toNight = true;
    public bool toDay = false;
    public float start = 1f;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {

        TilemapCo.color = new Color(currentco, currentco, currentco);
        CollCo.color = new Color(currentco, currentco, currentco);
    }

    // Update is called once per frame
    void Update()
    {
        changeColour();
    }

    void changeColour()
    {
        if (Time.time >= timeChange)
        {
            if (currentco <= co && toNight == true)
            {
                
                currentco += 0.01f;
                toNight = false;
                toDay = true;
                StartCoroutine(WaitForTime());
            }
            else if (currentco >= start && toDay == true)
            {
                
                currentco -= 0.01f;
                toNight = true;
                toDay = false;
                StartCoroutine(WaitForTime());
            }
            else if (toNight == true)
            {
                currentco -= 0.01f;
                TilemapCo.color = new Color(currentco, currentco, currentco);
                CollCo.color = new Color(currentco, currentco, currentco);
                timeChange = Time.time + 0.2f;
                
            }              
            else if (toDay == true)
            {
                currentco += 0.01f;
                TilemapCo.color = new Color(currentco, currentco, currentco);
                CollCo.color = new Color(currentco, currentco, currentco);
                timeChange = Time.time + 0.2f;
            }
        }
    }


    private IEnumerator WaitForTime()
    {
        
        yield return new WaitForSeconds(waitTime);
        Debug.Log("yeet");
        changeColour();
    }
}
