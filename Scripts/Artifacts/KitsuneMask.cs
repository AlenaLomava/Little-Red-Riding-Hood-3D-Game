using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class KitsuneMask : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public List<EnemyMovementController> wolves;
    public List<GameObject> wolvesGameObjects;

    private float previousRange;

    //private void Awake()
    //{
    //    wolvesGameObjects = GameObject.FindGameObjectsWithTag("wolf").ToList();
    //    wolves = wolvesGameObjects.ConvertAll(enemy => enemy.GetComponent<EnemyMovementController>());
    //}

    public void OnEquip()
    {
        wolvesGameObjects = GameObject.FindGameObjectsWithTag("wolf").ToList();
        wolves = wolvesGameObjects.ConvertAll(enemy => enemy.GetComponent<EnemyMovementController>());

        previousRange = wolves.First().range;

        wolves.ForEach(movementScript => movementScript.range = 0);
        wolvesGameObjects.ForEach(obj => obj.GetComponent<EnemyAttack>().enabled = false);
        wolvesGameObjects.ForEach(obj => obj.GetComponent<NavMeshAgent>().isStopped = true);
    }

    public void OnRemove()
    {
        wolvesGameObjects = GameObject.FindGameObjectsWithTag("wolf").ToList();
        wolves = wolvesGameObjects.ConvertAll(enemy => enemy.GetComponent<EnemyMovementController>());

        wolves.ForEach(movementScript => movementScript.range = previousRange);
        wolvesGameObjects.ForEach(obj => obj.GetComponent<EnemyAttack>().enabled = true);
        wolvesGameObjects.ForEach(obj => obj.GetComponent<NavMeshAgent>().isStopped = false);
    }
}
