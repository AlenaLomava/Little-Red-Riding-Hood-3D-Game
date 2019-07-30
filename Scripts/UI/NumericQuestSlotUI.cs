using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumericQuestSlotUI : MonoBehaviour
{
    Goal currentGoal;

    public void SetGoal(Goal g)
    {
        currentGoal = g;

        Image questIcon = this.transform.Find("QuestImage").gameObject.GetComponent<Image>();
        questIcon.sprite = currentGoal.QuestIcon;

        currentGoal.OnGoalUpdate += UpdateText;

        UpdateText(currentGoal);
    }

    private void UpdateText(Goal g) {
        Text questCountText = this.transform.Find("QuestCount").gameObject.GetComponent<Text>();
        questCountText.text = g.CurrentAmount.ToString() + "/" + g.RequiredAmount.ToString();
    }

    private void OnDestroy()
    {
        currentGoal.OnGoalUpdate -= UpdateText;
    }
}
