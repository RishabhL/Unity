using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    public Image Icon;

    Item item;

    public void AddItem(Item newItem)
    {
        
        item = newItem;
        Icon.sprite = item.Icon;
        Icon.enabled = true;

    }
    public void RemoveItem()
    {
        item = null;

        Icon.sprite = null;
        Icon.enabled = false;

    }
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag.GetComponent<ItemUI>() != null)
        {
            Item tmp = Inventory.instance.items[eventData.pointerDrag.GetComponent<ItemUI>().originalparent.GetSiblingIndex()];

            Inventory.instance.items[eventData.pointerDrag.GetComponent<ItemUI>().originalparent.GetSiblingIndex()] = Inventory.instance.items[transform.GetSiblingIndex()];

            Inventory.instance.items[transform.GetSiblingIndex()] = tmp;
        }
        else if (eventData.pointerDrag.GetComponent<HSlotItemUI>() != null)
        {
            Item tmp = Hotbar.instance.items[eventData.pointerDrag.GetComponent<HSlotItemUI>().originalparent.GetSiblingIndex()];
            Hotbar.instance.items[eventData.pointerDrag.GetComponent<HSlotItemUI>().originalparent.GetSiblingIndex()] = Inventory.instance.items[transform.GetSiblingIndex()];
            Inventory.instance.items[transform.GetSiblingIndex()] = tmp;
        }
        
    }
}
