using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipper : MonoBehaviour
{
    private KitsuneMask kitsuneMask;
    private HealthAmulet healthAmulet;
    private Axe axe;
    private GameObject player;
    public Artifact currentArtifact;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        kitsuneMask = player.transform.GetComponentInChildren<KitsuneMask>(true);
        healthAmulet = player.transform.GetComponentInChildren<HealthAmulet>(true);
        axe = player.transform.GetComponentInChildren<Axe>(true);
    }

    public void EquipCurrentArtifact()
    {
        ShowArtifactOnPalyer(currentArtifact);       
        currentArtifact.isEquipped = true;
        UseArtifact(currentArtifact);
    }

    public void RemoveCurrentArtifact()
    {
        HideArtifactOnPalyer(currentArtifact);
        currentArtifact.isEquipped = false;
        RemoveArtifact(currentArtifact);
    }

    private void UseArtifact(Artifact artifact)
    {
        switch (artifact.Type)
        {
            case ArtifactType.Amulet:
                healthAmulet.OnEquip();
                break;
            case ArtifactType.Mask:
                kitsuneMask.OnEquip();
                break;
            case ArtifactType.Axe:
                axe.OnEquip();
                break;
        }
    }

    private void RemoveArtifact(Artifact artifact)
    {
        switch (artifact.Type)
        {
            case ArtifactType.Amulet:
                healthAmulet.OnRemove();
                break;
            case ArtifactType.Mask:
                kitsuneMask.OnRemove();
                break;
            case ArtifactType.Axe:
                axe.OnRemove();
                break;
        }
    }

    private void ShowArtifactOnPalyer(Artifact artifact)
    {
        switch(artifact.Type)
        {
            case ArtifactType.Amulet:
                healthAmulet.gameObject.SetActive(true);
                break;
            case ArtifactType.Mask:
                kitsuneMask.gameObject.SetActive(true);
                break;
            case ArtifactType.Axe:
                axe.gameObject.SetActive(true);
                break;
        }
    }

    private void HideArtifactOnPalyer(Artifact artifact)
    {
        switch (artifact.Type)
        {
            case ArtifactType.Amulet:
                healthAmulet.gameObject.SetActive(false);
                break;
            case ArtifactType.Mask:
                kitsuneMask.gameObject.SetActive(false);
                break;
            case ArtifactType.Axe:
                axe.gameObject.SetActive(false);
                break;
        }
    }
}
