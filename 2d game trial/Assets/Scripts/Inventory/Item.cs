using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    // Item class
    public string Itemname = "New Item";
    public Sprite Icon = null;
    public GameObject itemprefab;
    public int Damage_Actual;
    public Rarity Rarity;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
public enum Rarity { Common, Uncommon, Rare, Epic, Legendary}