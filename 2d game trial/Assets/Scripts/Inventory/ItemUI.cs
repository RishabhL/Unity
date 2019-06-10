using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    
    public Transform originalparent;

    Vector3 startposition;
    Item currentitem;
    Item newitem;
    

    public void Awake()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startposition = transform.position;
        originalparent = transform.parent.parent;
        transform.SetParent(transform.parent.parent.parent.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startposition;
        transform.SetParent(originalparent.GetChild(0));
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            GameObject player = GameObject.Find("Player");
            Instantiate(Inventory.instance.items[eventData.pointerDrag.GetComponent<ItemUI>().originalparent.GetSiblingIndex()].itemprefab, new Vector3(player.transform.position.x - 1f, player.transform.position.y, player.transform.position.x) , Quaternion.identity);
            Inventory.instance.items[eventData.pointerDrag.GetComponent<ItemUI>().originalparent.GetSiblingIndex()] = null;
        }

        Inventory.instance.onItemChangedCallback.Invoke();
        Hotbar.instance.onItemChangedCallback.Invoke();
    }
    
}
