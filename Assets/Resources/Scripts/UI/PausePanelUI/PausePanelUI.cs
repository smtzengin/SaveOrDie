using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanelUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    public void Resume()
    {
        if (resumeButton != null)
        {
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void BackToMainMenu()
    {
        if(mainMenuButton != null)
        {
            SceneManager.LoadScene(0);
            Destroy(UIManager.Instance.gameObject);
        }
    }
}
