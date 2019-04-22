using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armour", menuName = "Inventory/Armour")]
public class ArmourItem : Item
{
    public ArmourSlot equipslot;
    public int armour;
}
public enum ArmourSlot {Head, Chest, Legs, Feet}