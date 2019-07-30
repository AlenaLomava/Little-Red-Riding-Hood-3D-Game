using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    public int healthBonus = 10;

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.currentHealth += healthBonus;
            Destroy(gameObject);
        }
    }

    public static void Create(Vector3 position)
    {
        position.y = position.y + 1;
        Instantiate(Resources.Load("Prefabs/HealthBonus"), position, Quaternion.identity);
    }
}
