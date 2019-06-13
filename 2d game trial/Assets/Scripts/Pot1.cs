using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot1 : MonoBehaviour
{
    private Animator anim;
    private int rnd;
    public GameObject HeartModule;
    public GameObject Coin;
    public Item[] Axe = new Item[5];
    public Item[] Spear = new Item[5];
    public GameObject axe;
    public GameObject spear;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Animating the pot to "Smash"
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

    // Spawning a random item when the pot is smasheds
    void SpawnRandom()
    {
        int rnd = Random.Range(1, 11);
        if (rnd <= 4)
        {
            Instantiate(HeartModule, transform.position, Quaternion.identity);
        }
        if (rnd > 4 && rnd < 7)
        {
            Instantiate(Coin, transform.position, Quaternion.identity);
        }
        if (rnd >= 7)
        {
            int rnd_w = Random.Range(1, 3);
            if (rnd_w == 1)
            {

                int rar_rnd = Random.Range(1, 16);
                if (rar_rnd <= 2)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[0];
                }
                else if (rar_rnd > 2 && rar_rnd < 5)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[1];
                }
                else if (rar_rnd >= 5 && rar_rnd < 9)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[2];
                }
                else if (rar_rnd >= 9 && rar_rnd < 13)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[3];
                }
                else if (rar_rnd >= 13 && rar_rnd < 16)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[4];
                }

                Instantiate(axe, transform.position, Quaternion.identity);
            }

            else if (rnd_w == 2)
            {
                int rar_rnd = Random.Range(1, 16);
                if (rar_rnd <= 2)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[0];
                }
                else if (rar_rnd > 2 && rar_rnd < 5)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[1];
                }
                else if (rar_rnd >= 5 && rar_rnd < 9)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[2];
                }
                else if (rar_rnd >= 9 && rar_rnd < 13)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[3];
                }
                else if (rar_rnd >= 13 && rar_rnd < 16)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[4];
                }

                Instantiate(spear, transform.position, Quaternion.identity);
            }
        }



    }
}
