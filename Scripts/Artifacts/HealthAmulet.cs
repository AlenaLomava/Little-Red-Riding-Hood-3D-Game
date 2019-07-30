using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAmulet : MonoBehaviour
{
    public int healthIncreasedPercentage = 20;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject healthSlider;

    public void OnEquip()
    {
        float changeCoefficient = ((float) 100 + healthIncreasedPercentage) / 100;
        playerHealth.startingHealth = (int) Mathf.Round(playerHealth.startingHealth * changeCoefficient);
        playerHealth.currentHealth  = (int) Mathf.Round(playerHealth.currentHealth * changeCoefficient);
        healthSlider.transform.localScale += new Vector3(changeCoefficient - 1, 0, 0);
    }

    public void OnRemove()
    {
        float changeCoefficient = ((float) 100 + healthIncreasedPercentage) / 100;
        playerHealth.startingHealth = (int) Mathf.Round(playerHealth.startingHealth / changeCoefficient);
        playerHealth.currentHealth  = (int) Mathf.Round(playerHealth.currentHealth / changeCoefficient);
        healthSlider.transform.localScale -= new Vector3(changeCoefficient - 1, 0, 0);
    }
}
