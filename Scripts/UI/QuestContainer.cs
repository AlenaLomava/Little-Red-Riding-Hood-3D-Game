using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestContainer : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager.LevelDescription.Goals.ForEach(g => InitQuestPanel(g));
    }

   private void InitQuestPanel(Goal g)
    {
        GameObject questUISlot = Instantiate(Resources.Load("Prefabs/UI/QuestUI/NumericQuestUI")) as GameObject;
        NumericQuestSlotUI questSlotScript = questUISlot.GetComponent<NumericQuestSlotUI>();
        questSlotScript.SetGoal(g);
        //questUISlot.transform.parent = transform;
        questUISlot.transform.SetParent(transform);

        Image questIcon = questUISlot.transform.Find("QuestImage").gameObject.GetComponent<Image>();
        questIcon.sprite = g.QuestIcon;

    }

}
