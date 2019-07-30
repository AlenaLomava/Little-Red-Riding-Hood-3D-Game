using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
    [SerializeField] private int damagePerKnifeAttack;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;

    private RaycastHit attackHit;
    private Animator anim;

    private int DamagePerKnifeAttack { get => damagePerKnifeAttack; set => damagePerKnifeAttack = value; }
    private Transform AttackPoint { get => attackPoint; set => attackPoint = value; }
    private float AttackRange { get => attackRange; set => attackRange = value; }

    public bool IsAttacking { get; set; }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("IsAttacking");
            Invoke("Attack", 0.4f);

        }
    }

    private void Attack()
    {
        Collider[] hittedObjects = Physics.OverlapSphere(AttackPoint.position, AttackRange);

        for (int i = 0; i < hittedObjects.Length; i++)
        {
            if (!GameObject.Equals(hittedObjects[i].gameObject, gameObject))
            {
                IDestructable destructable = hittedObjects[i].gameObject.GetComponent<IDestructable>();

                if (destructable != null)
                {
                    destructable.TakeDamage(DamagePerKnifeAttack);
                    break;
                }
            }
        }
    }
}
