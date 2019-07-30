using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Xml.Linq;

public class MainMenu : MonoBehaviour
{
    public GameObject aboutPanel;

    private void Start()
    {
        aboutPanel.SetActive(false);
        GameState.Instance.AudioManager.PlayMusic();
        GameState.Instance.AudioManager.StopSound("ForestAmbience");
    }

    public void StartGame()
    {
        Inventory.instance.ClearInventory();
        Inventory.instance.SaveControlPoint();
        Inventory.instance.removeAllArtifactsFromPlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void About()
    {
       aboutPanel.SetActive(true);
    }

    public void CloseAbout()
    {
        aboutPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}