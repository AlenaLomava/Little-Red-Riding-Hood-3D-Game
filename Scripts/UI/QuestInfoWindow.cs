using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfoWindow : MonoBehaviour
{
    public GameManager gameManager;
    LevelDescription levelDescription;
    // Start is called before the first frame update
    void Start()
    {
        levelDescription = gameManager.LevelDescription;
        string[] goalDescriptuions = levelDescription.Goals.ConvertAll<string>(g => g.Description).ToArray();
        string message = "To complete the level you need to:\n" + string.Join("\n", goalDescriptuions);

        Text goalsMessage = this.transform.Find("TextForGoals").gameObject.GetComponent<Text>();
        goalsMessage.text = message;

        SetQuestText(levelDescription.Description);
    }

    public void SetQuestText(string questText) {
        if (questText == null) { questText = gameManager.LevelDescription.Description; }
        Text questMessage = this.transform.Find("TextForQuest").gameObject.GetComponent<Text>();
        questMessage.text = questText;
    }

}
