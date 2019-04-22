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
        originalparent = transform.parent;
        Debug.Log(originalparent);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startposition = transform.position;
        transform.SetParent(transform.parent.parent.parent);
        currentitem = Inventory.instance.items[transform.parent.GetSiblingIndex()];
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.position = startposition;
        Debug.Log(originalparent);
        transform.SetParent(originalparent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            Debug.Log("Dropping onto Floor");
        }
        
    }
    
}
