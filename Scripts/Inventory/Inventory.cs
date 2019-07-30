using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {

        if (instance != null)
        {
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    public delegate void OnArtifactChanged();
    public OnArtifactChanged onArtifactChangedCallback;

    public int space = 6;

 
    public List<Artifact> artifacts = new List<Artifact>();
    public List<Artifact> controlPointArtifacts = new List<Artifact>();

    public bool Add(Artifact artifact)
    {
        if(artifacts.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;
        }

        artifacts.Add(artifact);
        artifact.isEquipped = false;
        RunCallback();
        return true;
    }

    public void SaveControlPoint()
    {
        controlPointArtifacts = new List<Artifact>(artifacts);
    }

    public void LoadControlPoint()
    {
        artifacts = new List<Artifact>(controlPointArtifacts);
        RunCallback();
    }


    public void ClearInventory()
    {
        artifacts = new List<Artifact>();
        RunCallback();
    }

    public void removeAllArtifactsFromPlayer() {
        artifacts.ForEach(artifact => artifact.isEquipped = false);
    }

    private void RunCallback()
    {
        if (onArtifactChangedCallback != null)
        {
            onArtifactChangedCallback.Invoke();
        }
    }
}
