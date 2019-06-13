using UnityEngine;

public class Chest : MonoBehaviour
{
    // Importing the needed components
    public Animator animator;
    private bool pressed = false;
    private bool isopened = false;
    private GameObject Player;
    public GameObject HeartModule;
    public GameObject Coin;
    public Item[] Axe = new Item[5];
    public Item[] Spear = new Item[5];
    public GameObject axe;
    public GameObject spear;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Opening the chest if the player enters "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            pressed = true;
        }

    }
    void OnTriggerStay2D(Collider2D collsion)
    {

        if (collsion.CompareTag("Player"))
        {
            if (pressed == true && isopened == false)
            {
                animator.SetBool("isopen", true);
                isopened = true;
                SpawnItem();

            }
        }

    }
    void OnTriggerExit2D(Collider2D collsion)
    {

        if (collsion.CompareTag("Player"))
        {
            if (pressed == true && isopened == false)
            {
                Debug.Log("Opened");
                animator.SetBool("isopen", true);
                isopened = true;
                SpawnItem();
            }
        }

    }
    // SPawning an item when the chest is opened
    void SpawnItem()
    {
        Vector3 distance = Player.transform.position - transform.position;

        int rnd = Random.Range(1, 11);
        if (rnd == 1)
        {
            Instantiate(HeartModule, transform.position - distance, Quaternion.identity);
        }
        if (rnd > 1 && rnd < 6)
        {
            Instantiate(Coin, transform.position - distance, Quaternion.identity);
        }
        if (rnd >= 6)
        {
            int rnd_w = Random.Range(1, 3);
            if (rnd_w == 1)
            {

                int rar_rnd = Random.Range(1, 16);
                if (rar_rnd <= 5)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[0];
                }
                else if (rar_rnd > 5 && rar_rnd < 10)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[1];
                }
                else if (rar_rnd >= 10 && rar_rnd < 13)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[2];
                }
                else if (rar_rnd >= 13 && rar_rnd < 15)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[3];
                }
                else if (rar_rnd == 15)
                {
                    axe.GetComponent<ItemPickup>().item = Axe[4];
                }

                Instantiate(axe, transform.position - distance, Quaternion.identity);
            }
            else if (rnd_w == 2)
            {
                int rar_rnd = Random.Range(1, 16);
                if (rar_rnd <= 5)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[0];
                }
                else if (rar_rnd > 5 && rar_rnd < 10)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[1];
                }
                else if (rar_rnd >= 10 && rar_rnd < 13)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[2];
                }
                else if (rar_rnd >= 13 && rar_rnd < 15)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[3];
                }
                else if (rar_rnd == 15)
                {
                    spear.GetComponent<ItemPickup>().item = Spear[4];
                }

                Instantiate(spear, transform.position - distance, Quaternion.identity);
            }
        }



    }


}
