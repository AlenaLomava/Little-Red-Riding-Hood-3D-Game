using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAttack : MonoBehaviour
{
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown(fireButton) && isReadyToAttack)
        {
            timer = 0;
            onAttack();
        }
    }

    public abstract void onAttack();
    public abstract string fireButton { get; }
    bool isReadyToAttack { get { return timer >= timeBetweenAttacks; } }
    public float timeBetweenAttacks = 0.5f;
    private float timer;

}
