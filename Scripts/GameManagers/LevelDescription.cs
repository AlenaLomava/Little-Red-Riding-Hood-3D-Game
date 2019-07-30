using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDescription : QuestManager
{
    public string Description;
  
    public void OnSceneLoad()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int sceneIndex = currentScene.buildIndex;

        if (sceneIndex == 1)
        {
            Description = "Bouquet for granny";
            Goals = new List<Goal>
            {
                new CollectionGoal(this, "flower", 10, 0, false, "Collect 10 flowers")
            };
        }
        else if (sceneIndex == 2)
        {
            Description = "Gifts of the forest";
            Goals = new List<Goal>
            {
                new CollectionGoal(this, "mushroom", 10, 0, false, "Collect 10 mushrooms")
            };
        }
        else if (sceneIndex == 3)
        {
            Description = "Revenge in the forest";
            Goals = new List<Goal>
            {
                new CollectionGoal(this, "key", 1, 0, false, "Find a key from granny house"),
                new KillGoal(this, "wolf", 15, 0, false, "Kill 15 wolves")
            };
        }

        Goals.ForEach(g => g.Init());
    }
}
