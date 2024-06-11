using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public QuestPanel questPanel;
    public QuestDataSO currentQuest;
    private event Action onQuestCompleted;
    public bool isQuestStarted;

    private void Awake()
    {
        instance = this;
    }

    public void StartQuest(QuestDataSO questData, Action onQuestCompleted = null)
    {
        this.currentQuest = questData;
        this.onQuestCompleted = onQuestCompleted;
        currentQuest.currentCount = 0;
        questPanel.gameObject.SetActive(true);
        questPanel.titleText.text = questData.title;
        questPanel.targetObjectImage.sprite = questData.targetObject;
        isQuestStarted = true;
        UpdateQuestProgress();
    }

    public void UpdateQuestProgress()
    {
        questPanel.questCountText.text = $"{currentQuest.currentCount} / {currentQuest.totalCount}";
    }

    public void IncrementQuestProgress(int amount)
    {
        currentQuest.currentCount += amount;
        if (currentQuest.currentCount >= currentQuest.totalCount)
        {
            FinishQuest();
        }
        else
        {
            UpdateQuestProgress();
        }
    }

    private void FinishQuest()
    {
        questPanel.gameObject.SetActive(false);
        onQuestCompleted?.Invoke();
        if(currentQuest.targetTag == "Enemy")
        {
            //TO DO: portal aktif
            GameManager.Instance.ActivateTeleport();
        }
        else if(currentQuest.targetTag == "Boss")
        {
            //TO DO: Save the girl
            UIManager.Instance.ShowEndGamePanel();
        }
        
    }
}
