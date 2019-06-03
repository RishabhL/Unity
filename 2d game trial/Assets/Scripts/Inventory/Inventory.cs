using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public static Inventory instance;
    public int space = 30;
    public List<Item> items = new List<Item>(30);



    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    void Awake()
    {
        instance = this;

    }

    public bool Add(Item item)
    {
        for (int i = 0; i < space; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                Debug.Log("Added Item" + items[i]);
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return true;
            }
        }

        Debug.Log("Not enough room!");
        return false;
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
