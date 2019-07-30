using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEvents
{
    public delegate void EnemyEventHandler(IDestructable enemy);
    public static event EnemyEventHandler OnEnemyDeath;

    public static void EnemyDied(IDestructable enemy)
    {
        if (OnEnemyDeath != null)
            OnEnemyDeath(enemy);
    }
}
