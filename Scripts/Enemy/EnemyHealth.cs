using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour, IDestructable 
{
    public int startingHealth = 40;
    public int currentHealth;
    public float timeGOPresentsAtScene = 40f;

    private Animator anim;
    private bool isDead;
    private bool goToGround = false;

    public int Health
    {
        get { return startingHealth; }
        set { startingHealth = value; }
    }

    public string EnemyTag {
        get { return this.tag; }
    }


    void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }
        currentHealth -= amount;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        if(anim != null)
        {
            anim.SetBool("IsEnemyAttacks", false);
            anim.SetTrigger("Dead");
            if (Random.Range(0, 100) < 25)
            {
                HealthBonus.Create(transform.position);
            }
        }

        isDead = true;
        CombatEvents.EnemyDied(this);
        Destroy(gameObject, timeGOPresentsAtScene);
    }

}
