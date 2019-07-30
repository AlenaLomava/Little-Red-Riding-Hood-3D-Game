using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionEvents 
{
    public delegate void QuestItemEventHandler(ICollectableItem item);
    public static event QuestItemEventHandler OnQuestItemAdded;

    public static void ItemAdded(GameObject item)
    {
        var questItem = item.GetComponent<ICollectableItem>();
        executeQuestItemAddedCallback(questItem);
    }

    private static void executeQuestItemAddedCallback(ICollectableItem item)
    {
        OnQuestItemAdded?.Invoke(item);
    }
}
