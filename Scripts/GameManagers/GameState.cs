using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameState { Pause, Playing, Death, GameOver, BeatLevel };

public class GameState : MonoBehaviour
{
    private gameState _state;
    public delegate void OnGameStateUpdateCallback(gameState newState);
    public static event OnGameStateUpdateCallback OnGameStateUpdate;

    [SerializeField]
    private AudioManager audioManager;
    public AudioManager AudioManager
    {
        get { return audioManager; }
    }

    public gameState State {
        get { return _state; }
        set {
            _state = value;
            OnGameStateUpdate?.Invoke(value);
        }
    }

    public static GameState _instance;
    public static GameState Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameState>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("GameState");
                    _instance = container.AddComponent<GameState>();
                }
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);

        InitializeAudioManager();
    }

    private void InitializeAudioManager()
    {
        audioManager.SourceSFX = gameObject.AddComponent<AudioSource>();
        audioManager.SourceMusic = gameObject.AddComponent<AudioSource>();
        audioManager.SourceRandomPitchSFX = gameObject.AddComponent<AudioSource>();
        gameObject.AddComponent<AudioListener>();
    }
}
