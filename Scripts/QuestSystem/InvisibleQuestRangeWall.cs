using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleQuestRangeWall : MonoBehaviour
{
    public HUD hud;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null) {
            hud.OpenQuestInfoWindow("Sorry, but you can't leave the area until you are done with tasks");
        }
    }

}
