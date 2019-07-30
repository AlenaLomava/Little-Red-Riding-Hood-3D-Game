using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    public float range = 3f;

    private Transform player;
    private NavMeshAgent nav;
    private Animator anim;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) <= range)
        {
            nav.SetDestination(player.position);

            if (anim != null)
            {
                anim.SetBool("EnemyIsWalking", true);
            }
        }
        else
        {
            if (anim != null)
            {
                anim.SetBool("EnemyIsWalking", false);
            }
        }
    }
}
