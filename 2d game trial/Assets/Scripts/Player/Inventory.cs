using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public static Inventory instance;
    public int space = 30;
    public int count = 30;
    public List<Item> items = new List<Item>();



    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    void Awake()
    {
        instance = this;

    }

    public bool Add(Item item)
    {
        int count1 = 30;
        foreach (Item i in items)
        {
            if (i == null)
            {
                count1 -= 1;
            }
            count = count1;
        }

        if (count >= space)
        {
            Debug.Log("Not enough room");
            return false;
        }

        items[count] = item;
        Debug.Log("Adding Item");

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;

    }
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }


}
