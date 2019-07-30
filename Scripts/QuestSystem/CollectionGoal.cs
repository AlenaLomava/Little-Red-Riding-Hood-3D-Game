using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal
{

    public CollectionGoal(QuestManager questManager, string tag, int requiredAmount, int currentAmount, bool completed, string description)
    {
        this.QuestManager = questManager;
        this.Tag = tag;
        this.RequiredAmount = requiredAmount;
        this.CurrentAmount = currentAmount;
        this.Completed = completed;
        this.Description = description;
    }

    public override void Init()
    {
        base.Init();
        CollectionEvents.OnQuestItemAdded += ItemPickedUp;
    }

    void ItemPickedUp(ICollectableItem item)
    {
        if(item.ItemTag == this.Tag)
        {
            this.CurrentAmount++;
            Evaluate();
        }

    }
}
