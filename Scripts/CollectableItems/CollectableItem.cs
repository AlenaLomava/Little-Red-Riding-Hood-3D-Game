using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectableItem : MonoBehaviour, ICollectableItem
{
    public Artifact artifact;

    public string ItemTag { get => this.tag; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (artifact != null)
            {
                bool wasAddedToInventory = Inventory.instance.Add(this.artifact);
                if (wasAddedToInventory)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                CollectionEvents.ItemAdded(gameObject);
                Destroy(gameObject);
            }
            GameState.Instance.AudioManager.PlaySound("collect");
        }
    }
}
