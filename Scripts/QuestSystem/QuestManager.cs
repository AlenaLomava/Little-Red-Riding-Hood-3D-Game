using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestManager
{
    public List<Goal> Goals { get; set; }
    public bool Completed { get; set; }

    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
    }        
}
