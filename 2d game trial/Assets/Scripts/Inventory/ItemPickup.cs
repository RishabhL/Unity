using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pickup();

        }
    }
    void Pickup()
    {
        bool pickedup = Inventory.instance.Add(item);
        if (pickedup)
        { 
            Destroy(gameObject);
        }
    }

}
