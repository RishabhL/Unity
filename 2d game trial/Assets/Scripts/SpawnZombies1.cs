using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies1 : MonoBehaviour
{
    public bool day;
    public bool changing;
    public GameObject zombie;
    private float timeChange = 1f;
    private List<Vector3> spawnpoints = new List<Vector3>();
    private int zombies_spawned;
    private Vector3 randpos;
    // Start is called before the first frame update

    // Creating a list with all the locations the zomies can spawn in
    void Start()
    {
        for (int x = -37; x < -20; x++)
        {
            for (int y = -11; y < 26; y++)
            {
                spawnpoints.Add(new Vector3(x, y, 0));
            }
        }
        for (int x1 = -20; x1 < 14; x1++)
        {
            for (int y1 = -12; y1 < -6; y1++)
            {
                spawnpoints.Add(new Vector3(x1, y1, 0));
            }
        }
        for (int x2 = 15; x2 < 31; x2++)
        {
            for (int y2 = -12; y2 < 26; y2++)
            {
                spawnpoints.Add(new Vector3(x2, y2, 0));
            }
        }
        for (int x3 = -19; x3 < 14; x3++)
        {
            for (int y3 = 19; y3 < 26; y3++)
            {
                spawnpoints.Add(new Vector3(x3, y3, 0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // SPawning the zombies at a random position when it is nighttime.
        day = gameObject.GetComponent<NightDay>().day;
        changing = gameObject.GetComponent<NightDay>().ischanging;
        if (day == false && changing == false)
        {

            if (Time.time >= timeChange && zombies_spawned <= 25)
            {
                randpos = spawnpoints[Random.Range(0, spawnpoints.Count)];
                Debug.Log(randpos);
                Instantiate(zombie, randpos, Quaternion.identity);
                timeChange = Time.time + 5f;
                zombies_spawned += 1;
                Debug.Log(zombies_spawned);
            }
        }
        else {
            zombies_spawned = 0;
        }
        
    }
}
