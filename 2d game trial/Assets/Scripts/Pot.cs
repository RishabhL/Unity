using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator anim;
    private int rnd;
    public GameObject HeartModule;
    public GameObject Coin;
    public GameObject Axe;
    public GameObject Spear;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        anim.SetBool("Smashed", true);
        StartCoroutine(BreakObj());
    }

    IEnumerator BreakObj()
    {
        yield return new WaitForSeconds(0.3f);
        SpawnRandom();
        this.gameObject.SetActive(false);
    }
    void SpawnRandom()
    {
        rnd = Random.Range(1, 11);
        if (rnd == 1)
        {
            Instantiate(HeartModule, transform.position, Quaternion.identity);
        }
        if (rnd > 1 && rnd < 6)
        {
            Instantiate(Coin, transform.position, Quaternion.identity);
        }
        if (rnd >= 6)
        {
            int rnd_w = Random.Range(1, 2);
            if (rnd_w == 1)
            {
                Instantiate(Axe, transform.position, Quaternion.identity);
            }
            if (rnd_w == 2)
            {
                Instantiate(Spear, transform.position, Quaternion.identity);
            }
        }
        


    }
}
