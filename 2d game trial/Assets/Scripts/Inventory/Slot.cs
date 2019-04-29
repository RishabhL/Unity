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
        Debug.Log("Dropped");

        if (eventData.pointerDrag.GetComponent<ItemUI>() != null)
        {
            Item item = Inventory.instance.items[eventData.pointerDrag.GetComponent<ItemUI>().originalparent.GetSiblingIndex()];
            Inventory.instance.items.RemoveAt(eventData.pointerDrag.GetComponent<ItemUI>().originalparent.GetSiblingIndex());
            Inventory.instance.items.Insert(transform.GetSiblingIndex(), item);
        }
        else if (eventData.pointerDrag.GetComponent<HSlotItemUI>() != null)
        {
            Item item = Hotbar.instance.items[eventData.pointerDrag.GetComponent<HSlotItemUI>().originalparent.GetSiblingIndex()];
            Hotbar.instance.items.RemoveAt(eventData.pointerDrag.GetComponent<HSlotItemUI>().originalparent.GetSiblingIndex());
            Inventory.instance.items.Insert(transform.GetSiblingIndex(), item);
        }
        
    }
}
