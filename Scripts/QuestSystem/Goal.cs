using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public Sprite QuestIcon
    {
        get { return Resources.Load<Sprite>("ItemIcons/" + this.Tag); }
    }

    public string Description { get; set; }

    public QuestManager QuestManager { get; set; }
    public string Tag { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }

    public delegate void GoalEventHandler(Goal goal);
    public event GoalEventHandler OnGoalUpdate;

    public virtual void Init()
    {
        // default init stuff
    }

    public void Evaluate()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
        OnGoalUpdate?.Invoke(this);
    }

    public void Complete()
    {
        Completed = true;
        this.QuestManager.CheckGoals();
        Debug.Log("Goal marked as completed.");
    }

}
