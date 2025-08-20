using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public DialoguePanel dialoguePanel;
    public DialogueDataSO initialDialogue;
    public QuestManager questManager;


    private void Start()
    {
        ShowDialogue(initialDialogue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            dialoguePanel.nextButton.onClick.Invoke(); 
        }
    }
    public void ShowDialogue(DialogueDataSO dialogue)
    {
        dialoguePanel.characterImage.sprite = dialogue.CharacterImage;
        dialoguePanel.titleText.text = dialogue.Title;
        dialoguePanel.contentText.text = dialogue.Content;
        dialoguePanel.nextButton.onClick.RemoveAllListeners();
        dialoguePanel.nextButton.onClick.AddListener(() => OnNextButtonClicked(dialogue));
    }

    private void OnNextButtonClicked(DialogueDataSO dialogue)
    {
        dialoguePanel.gameObject.SetActive(false);
        questManager.StartQuest(dialogue.QuestData);
    }
}
