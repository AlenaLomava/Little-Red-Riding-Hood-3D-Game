using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private ShootingController shootingController;

    private void Start()
    {
        //player = GameObject.FindWithTag("Player");
        //shootingController = player.GetComponentInChildren<ShootingController>();
    }

    public void OnEquip()
    {
        shootingController.enabled = true;
    }

    public void OnRemove()
    {
        shootingController.enabled = false;
    }
}
