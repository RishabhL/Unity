using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    public bool day;
    public bool changing;
    public GameObject zombie;
    private float timeChange = 1f;

    Vector3 randpos;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        day = gameObject.GetComponent<NightDay>().day;
        changing = gameObject.GetComponent<NightDay>().ischanging;
        if (day == false && changing == false)
        {
            
            if (Time.time >= timeChange)
            {
                randpos = new Vector3(Random.Range(-17, 12), Random.Range(-3, 16), 0);
                Instantiate(zombie, randpos, Quaternion.identity);
                timeChange = Time.time + 1f;
            }
        }
        
    }
}
