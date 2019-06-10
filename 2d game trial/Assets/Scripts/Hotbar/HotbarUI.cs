using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarUI : MonoBehaviour
{
    public Transform Hslots;
    private int count;

    Hotbar hotbar;

    HSlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        hotbar = Hotbar.instance;
        hotbar.onItemChangedCallback += UpdateUI;

        slots = Hslots.GetComponentsInChildren<HSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI()
    {
        for (int i = 0; i < hotbar.items.Count; i++)
        {
            if (hotbar.items[i] != null)
            {
                slots[i].AddItem(hotbar.items[i]);

            }
            else
            {
                slots[i].RemoveItem();
            }


        }
    }
}
