using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HSlot : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("Dropped");
        //if (eventData.pointerDrag.GetComponent<ItemUI>() != null)
        //{
        //    Item tmp = Inventory.instance.items[eventData.pointerDrag.GetComponent<ItemUI>().originalparent.GetSiblingIndex()];
        //    Inventory.instance.items[eventData.pointerDrag.GetComponent<ItemUI>().originalparent.GetSiblingIndex()] = Inventory.instance.items[transform.GetSiblingIndex()];
        //    Inventory.instance.items[transform.GetSiblingIndex()] = tmp;
        //}
        //else if (eventData.pointerDrag.GetComponent<HSlotItemUI>() != null)
        //{
        //    Item tmp = Hotbar.instance.items[eventData.pointerDrag.GetComponent<HSlotItemUI>().originalparent.GetSiblingIndex()];
        //    Hotbar.instance.items[eventData.pointerDrag.GetComponent<ItemUI>().originalparent.GetSiblingIndex()] = Inventory.instance.items[transform.GetSiblingIndex()];
        //    Inventory.instance.items[transform.GetSiblingIndex()] = tmp;
        //}
    }
}
