using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    private Artifact artifact;
    public Image icon;
    public HUD hudCanvas;


    public void AddArtifact(Artifact artifact)
    {
        this.artifact = artifact;


        
        icon.sprite = artifact.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
    }

    public void OpenInfoBox()
    {
        GameObject itemWindow = hudCanvas.itemInfoWindow;

        Equipper equipper = itemWindow.GetComponent<Equipper>();
        equipper.currentArtifact = artifact;

        Text artifactNameTextField = itemWindow.transform.Find("ItemName").gameObject.GetComponent<Text>();
        Text artifactDescriptionTextField = itemWindow.transform.Find("ItemDescription").gameObject.GetComponent<Text>();
        artifactNameTextField.text = artifact.name;
        artifactDescriptionTextField.text = artifact.description;

        GameObject equipButton = itemWindow.transform.Find("EquipButton").gameObject;
        GameObject removeButton = itemWindow.transform.Find("RemoveButton").gameObject;
        equipButton.SetActive(!artifact.isEquipped);
        removeButton.SetActive(artifact.isEquipped);

        hudCanvas.OpenInventoryInfoBox();
    }
}
