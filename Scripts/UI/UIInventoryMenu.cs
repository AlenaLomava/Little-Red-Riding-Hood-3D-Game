using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInventoryMenu : MonoBehaviour
{
    private Inventory inventory;
    public Transform artifactsParent;
    UIInventorySlot[] slots;

    public void Start()
    {
        inventory = Inventory.instance;
        inventory.onArtifactChangedCallback += UpdateUI;
        slots = artifactsParent.GetComponentsInChildren<UIInventorySlot>();
        UpdateUI();
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.artifacts.Count)
            {
                slots[i].AddArtifact(inventory.artifacts[i]);
                Debug.Log("Slot " + slots.Length);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void OnDestroy()
    {
        Debug.Log("disabled callbacks");
        Inventory.instance.onArtifactChangedCallback -= UpdateUI;
        //CollectionEvents.OnInventoryItemAdded -= AddItem;
        //SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
