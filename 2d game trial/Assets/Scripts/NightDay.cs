using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NightDay : MonoBehaviour
{
    public Tilemap TilemapCo;
    public Tilemap CollCo;

    public float co = 0.48f;
    public float currentco = 1f;
    private float timeChange = 0.2f;

    public bool day = true;
    public bool ischanging = false;
    public float WaitSeconds = 5f;


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (day == true)
        {
            if (ischanging == false)
            {
                StartCoroutine(WaitDay());
            }
            else
            {
                ChangeDay();
            }
        }
        else
        {
            if (ischanging == false)
            {
                StartCoroutine(WaitNight());
            }
            else
            {
                ChangeNight();
            }
        }

    }
    void ChangeDay()
    {
        if (currentco <= 1f)
        {
            if (Time.time >= timeChange)
            {
                currentco += 0.01f;
                TilemapCo.color = new Color(currentco, currentco, currentco);
                CollCo.color = new Color(currentco, currentco, currentco);
                timeChange = Time.time + 1f;
            }
        }
        else
        {
            day = true;
            ischanging = false;
        }
    }
    void ChangeNight()
    {
        if (currentco >= co)
        {
            if (Time.time >= timeChange)
            {
                currentco -= 0.01f;
                TilemapCo.color = new Color(currentco, currentco, currentco);
                CollCo.color = new Color(currentco, currentco, currentco);
                timeChange = Time.time + 1f;
            }
        }
        else
        {
            day = false;
            ischanging = false;
        }
    }
    public IEnumerator WaitDay()
    {
        yield return new WaitForSecondsRealtime(WaitSeconds);
        day = false;
        ischanging = true;
    }
    public IEnumerator WaitNight()
    {
        yield return new WaitForSecondsRealtime(WaitSeconds);
        day = true;
        ischanging = true;
    }

}
