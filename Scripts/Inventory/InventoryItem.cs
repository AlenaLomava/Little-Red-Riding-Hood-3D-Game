using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IInventoryItem
{
    public string itemName;
    public string description;
    public Sprite icon;

    public string ItemTag { get { return tag; } }
    public string Name { get { return itemName; } }
    public string Description { get { return description; } }

    public Sprite Icon { get { return icon; } }

    private bool equipped;

    public bool isEquipped()
    {
        return equipped;
    }

    public void EquipPlayer(GameObject player) { }
    public void RemoveFromPlayer(GameObject player) { }
}
