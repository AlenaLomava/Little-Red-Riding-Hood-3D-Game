using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject menuWindow;
    [SerializeField] private GameObject inventoryWindow;
    [SerializeField] public GameObject itemInfoWindow;
    [SerializeField] public GameObject questInfoWindow;
    [SerializeField] public GameObject settingsWindow;

    private CameraFollow cameraFollow;

    private void Start()
    {
        inventoryWindow.SetActive(false);
        menuWindow.SetActive(false);
        settingsWindow.SetActive(false);

        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        UIInventoryMenu inventoryMenu = inventoryWindow.GetComponent<UIInventoryMenu>();

        OpenQuestInfoWindow();
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (cameraFollow.enabled)
            {
                OpenWindow(menuWindow);
            }
        }
    }

    public void OpenWindow(GameObject window)
    {
        window.SetActive(true);
        GameState.Instance.State = gameState.Pause;
        cameraFollow.enabled = false;
    }

    public void HideWindow(GameObject window)
    {
        GameState.Instance.State = gameState.Playing;
        window.SetActive(false);
        cameraFollow.enabled = true;
    }

    public void OpenMenuWindow()
    {
        HideWindow(inventoryWindow);
        OpenWindow(menuWindow);
    }

    public void HideMenuWindow()
    {
        HideWindow(menuWindow);
    }

    public void OpenSettingsWindow()
    {
        HideWindow(menuWindow);
        OpenWindow(settingsWindow);
    }

    public void HideSettingsWindow()
    {
        HideWindow(settingsWindow);
        OpenWindow(menuWindow);
    }

    public void OpenInventoryWindow()
    {
        HideWindow(menuWindow);
        OpenWindow(inventoryWindow);
    }

    public void OpenInventoryInfoBox()
    {
        OpenWindow(itemInfoWindow);
    }

    public void CloseInventoryInfoBox()
    {
        HideWindow(itemInfoWindow);
        OpenWindow(inventoryWindow);
    }

    public void CloseQuestInfoWindow()
    {
        HideWindow(questInfoWindow);
    }

    public void OpenQuestInfoWindow(string questText = null)
    {
        questInfoWindow.GetComponent<QuestInfoWindow>().SetQuestText(questText);
        OpenWindow(questInfoWindow);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        GameState.Instance.State = gameState.Playing;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        Inventory.instance.LoadControlPoint();
        Inventory.instance.removeAllArtifactsFromPlayer();
        HideWindow(menuWindow);
    }

    public void SetSoundVolume(Slider slider)
    {
        GameState.Instance.AudioManager.SfxVolume = slider.value;
    }
    public void SetMusicVolume(Slider slider)
    {
        GameState.Instance.AudioManager.MusicVolume = slider.value;
    }
}
