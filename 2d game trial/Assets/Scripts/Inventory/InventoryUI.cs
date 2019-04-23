using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform slotsparent;
    public GameObject inventoryUI;
    private int count;

    Inventory inventory;

    Slot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        count = Inventory.instance.count;
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = slotsparent.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < count)
            {
                if (inventory.items[i] != null)
                {
                    slots[i].AddItem(inventory.items[i]);
                }
                else
                {
                    slots[i].RemoveItem();
                }
            }
            else
            {
                slots[i].RemoveItem();
            }
        }

    }
}
