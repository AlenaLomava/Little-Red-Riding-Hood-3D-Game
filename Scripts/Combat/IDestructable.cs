using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestructable 
{
    int Health { get; set; }
    void TakeDamage(int amount);
    void Death();
    string EnemyTag { get; }

}
