using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{
    public KillGoal(QuestManager questManager, string tag, int requiredAmount, int currentAmount, bool completed, string description)
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
        CombatEvents.OnEnemyDeath += EnemyDied;
    }

    void EnemyDied(IDestructable enemy)
    {
        if(enemy.EnemyTag == this.Tag)
        {
            this.CurrentAmount++;
            Evaluate();
        }

    }
}
