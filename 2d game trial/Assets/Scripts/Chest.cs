using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;
    private bool pressed = false;
    private bool isopened = false;
    private GameObject Player;
    public GameObject HeartModule;
    public GameObject Coin;
    public GameObject Axe;
    public GameObject Spear;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed");
            pressed = true;
        }

    }
    void OnTriggerStay2D(Collider2D collsion)
    {

        if (collsion.CompareTag("Player"))
        {
            Debug.Log("in");
            if (pressed == true && isopened == false)
            {
                Debug.Log("Opened");
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
            Debug.Log("out");
            if (pressed == true && isopened == false)
            {
                Debug.Log("Opened");
                animator.SetBool("isopen", true);
                isopened = true;
                SpawnItem();
            }
        }

    }
    void SpawnItem()
    {
        Vector3 distance = Player.transform.position - transform.position;
        int rnd = Random.Range(1, 11);
        if (rnd == 1)
        {
            Instantiate(HeartModule, transform.position + distance, Quaternion.identity);
        }
        if (rnd > 1 && rnd < 6)
        {
            Instantiate(Coin, transform.position + distance, Quaternion.identity);
        }
        if (rnd >= 6)
        {
            int rnd_w = Random.Range(1, 2);
            if (rnd_w == 1)
            {
                Instantiate(Axe, transform.position + distance, Quaternion.identity);
            }
            if (rnd_w == 2)
            {
                Instantiate(Spear, transform.position + distance, Quaternion.identity);
            }
        }



    }
}
