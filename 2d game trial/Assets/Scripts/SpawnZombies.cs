using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    public bool day;
    public bool changing;
    public GameObject zombie;
    private float timeChange = 1f;
    private List<Vector3> spawnpoints = new List<Vector3>();
    private int zombies_spawned;
    private Vector3 randpos;
    // Start is called before the first frame update

    void Start()
    {
        for (int x = -17; x < -11; x++)
        {
            for (int y = 12; y < 15; y++)
            {
                spawnpoints.Add(new Vector3(x, y, 0));
            }
        }
        for (int x1 = -1; x1 < 12; x1++)
        {
            for (int y1 = 14; y1 < 16; y1++)
            {
                spawnpoints.Add(new Vector3(x1, y1, 0));
            }
        }
        for (int x2 = -3; x2 < 12; x2++)
        {
            for (int y2 = 14; y2 < 16; y2++)
            {
                spawnpoints.Add(new Vector3(x2, y2, 0));
            }
        }
        for (int x3 = -17; x3 < -2; x3++)
        {
            for (int y3 = 1; y3 < 7; y3++)
            {
                spawnpoints.Add(new Vector3(x3, y3, 0));
            }
        }
        for (int x4 = 8; x4 < 12; x4++)
        {
            for (int y4 = 0; y4 < 10; y4++)
            {
                spawnpoints.Add(new Vector3(x4, y4, 0));
            }
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        day = gameObject.GetComponent<NightDay>().day;
        changing = gameObject.GetComponent<NightDay>().ischanging;
        if (day == false && changing == false)
        {

            if (Time.time >= timeChange && zombies_spawned <= 18)
            {
                randpos = spawnpoints[Random.Range(0, spawnpoints.Count)];
                Debug.Log(randpos);
                Instantiate(zombie, randpos, Quaternion.identity);
                timeChange = Time.time + 3f;
                zombies_spawned += 1;
                Debug.Log(zombies_spawned);
            }
        }
        else {
            zombies_spawned = 0;
        }
        
    }
}
