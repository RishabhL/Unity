using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string Itemname = "New Item";
    public Sprite Icon = null;
    public GameObject itemprefab;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
