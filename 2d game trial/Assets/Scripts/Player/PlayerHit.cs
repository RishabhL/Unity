using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // If the player hits the pot, calling the function for the pot to "Smash"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable"))
        {
            if (collision.GetComponent<Pot>() != null)
            {
                collision.GetComponent<Pot>().Smash();
            }
            else if (collision.GetComponent<Pot>() != null)
            {
                collision.GetComponent<Pot1>().Smash();
            }
        }
    }
}   
    
