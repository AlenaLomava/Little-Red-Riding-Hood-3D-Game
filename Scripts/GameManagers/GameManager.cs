using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject player;

    void onGameStateUpdate(gameState state)
    {
        if (state == gameState.Playing)
        {
            Time.timeScale = 1.0f;
            LockCursor(true);
            GameState.Instance.AudioManager.PlaySound("ForestAmbience");
            GameState.Instance.AudioManager.StopMusic();
        }
        else if (state == gameState.Pause)
        {
            Time.timeScale = 0.0f;
            LockCursor(false);
            GameState.Instance.AudioManager.StopSound("ForestAmbience");
        }
    }

    public bool canBeatLevel;

    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public GameObject beatLevelCanvas;

    private LevelDescription levelDescription;
    public LevelDescription LevelDescription {
        get {
            if (levelDescription == null) {
                levelDescription = new LevelDescription();
                levelDescription.OnSceneLoad();
            }
            return levelDescription;
        }
    }

    private PlayerHealth playerHealth;

    private bool isCursorLock = true;

    private CameraFollow cameraFollow;

    private void Awake()
    {
        LockCursor(isCursorLock);
        gameOverCanvas.SetActive(false);
        if (canBeatLevel)
        {
            beatLevelCanvas.SetActive(false);
        }
        GameState.OnGameStateUpdate += onGameStateUpdate;
    }

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        switch (GameState.Instance.State)
        {
            case gameState.Playing:
                if (playerHealth.isDead)
                {
                    GameState.Instance.State = gameState.Death;
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                    
                }
                else if (canBeatLevel && LevelDescription.Completed)
                {
                    GameState.Instance.State = gameState.BeatLevel;
                    LockCursor(false);
                    cameraFollow.enabled = false;
                    player.SetActive(false);		
                    mainCanvas.SetActive(false);
                    beatLevelCanvas.SetActive(true);
                }
                break;
            case gameState.Death:
                //need to add some code
                GameState.Instance.State = gameState.GameOver;
                break;
            case gameState.BeatLevel:
                GameState.Instance.State = gameState.GameOver;

                //need to add some code
                break;
            case gameState.GameOver:
                LockCursor(false);
                cameraFollow.enabled = false;
                break;



        }
    }

    public void LoadNextLevel()
    {
        Debug.Log("Load next level");
        Inventory.instance.SaveControlPoint();
        Inventory.instance.removeAllArtifactsFromPlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    private void LockCursor(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnDestroy()
    {
        GameState.OnGameStateUpdate -= onGameStateUpdate;
    }
}
