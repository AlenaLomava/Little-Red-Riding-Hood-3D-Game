using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 8;

    private Animator anim;
    private GameObject player;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private bool playerInRange;
    private float timer;
    private bool enemyAttack = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!enabled) return;
        if (other.gameObject == player)
        {
            playerInRange = true;
            enemyAttack = true;
            if (anim != null)
            {
                anim.SetBool("IsEnemyAttacks", enemyAttack);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!enabled) return;
        if (other.gameObject == player)
        {
            playerInRange = false;
            enemyAttack = false;
            if (anim != null)
            {
                anim.SetBool("IsEnemyAttacks", enemyAttack);
            }
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
            if (enemyHealth.EnemyTag == "wolf")
            {
                GameState.Instance.AudioManager.PlaySound("wolfAttack");
            }
            else if (enemyHealth.EnemyTag == "mushroomEnemy")
            {
                GameState.Instance.AudioManager.PlaySound("mushroomAttack");
            }
        }

        if (playerHealth.currentHealth <= 0)
        {
            if (anim != null)
            {
                anim.SetBool("IsEnemyAttacks", false);
                anim.SetTrigger("PlayerDead");
            }
        }
    }

    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
        enemyAttack = true;
    }
}
