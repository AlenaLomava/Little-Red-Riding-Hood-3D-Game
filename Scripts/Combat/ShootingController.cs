using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gun;
    [SerializeField]
    private float shootPower = 130f;
    [SerializeField]
    private int bulletKillPower;

    private Animator anim;

    private bool isReadyToAttack { get { return timer >= timeBetweenAttacks; } }
    public float timeBetweenAttacks = 1f;
    private float timer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && isReadyToAttack)
        {
            timer = 0;
            anim.SetTrigger("IsShooting");
            Invoke("Shoot", 0.4f);
            GameState.Instance.AudioManager.PlaySound("AxeAttack");
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, gun.position, gun.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(gun.forward * shootPower);
        BulletDamager bulletBehaviour = newBullet.GetComponent<BulletDamager>();
        bulletBehaviour.Damage = bulletKillPower;
        bulletBehaviour.Owner = gameObject;
        Destroy(newBullet.gameObject, 5);
    }
}
