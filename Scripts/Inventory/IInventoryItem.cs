using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInventoryItem
{
    string ItemTag { get; }

    string Name { get; }
    string Description { get; }
    Sprite Icon { get; }

    bool isEquipped();

    void EquipPlayer(GameObject player);
    void RemoveFromPlayer(GameObject player);
}
