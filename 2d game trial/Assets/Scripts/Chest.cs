using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator animator;
    private bool pressed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            if (pressed == true)
            {
                Debug.Log("Opened");
                animator.SetBool("isopen", true);
                SpawnItem();

            }
        }

    }
    void OnTriggerExit2D(Collider2D collsion)
    {

        if (collsion.CompareTag("Player"))
        {
            Debug.Log("out");
            if (pressed == true)
            {
                Debug.Log("Opened");
                animator.SetBool("isopen", true);
            }
        }

    }
    void SpawnItem()
    {


    }

}
