using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamager : MonoBehaviour
{
    public GameObject Owner
    {
        get; internal set;
    }

    public int Damage
    {
        get; internal set;
    }

    private GameObject floor;

    private void Awake()
    {
        floor = GameObject.FindGameObjectWithTag("Floor");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!GameObject.Equals(collision.gameObject, Owner) && !GameObject.Equals(collision.gameObject, floor))
        {
            IDestructable destructable = collision.gameObject.GetComponent<IDestructable>();
            if (destructable != null)
            {
                destructable.TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
    }
}
