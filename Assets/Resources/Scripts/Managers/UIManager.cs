using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public UIScreen pausePanel;
    public UIScreen tryAgainPanel;
    public UIScreen endGamePanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (pausePanel != null)
        {
            pausePanel.gameObject.SetActive(false);
        }

        if (tryAgainPanel != null)
        {
            tryAgainPanel.gameObject.SetActive(false);
        }

        if (endGamePanel != null)
        {
            endGamePanel.gameObject.SetActive(false);
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPausePanel();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Sahne yüklendiğinde ilgili panelleri bulun ve ayarla
        pausePanel = FindObjectOfType<PausePanelUI>(true)?.GetComponent<UIScreen>();
        tryAgainPanel = FindObjectOfType<TryAgainPanelUI>(true)?.GetComponent<UIScreen>();
        endGamePanel = FindObjectOfType<EndGamePanelUI>(true)?.GetComponent<UIScreen>();
    }

    public void ShowPausePanel()
    {
        if (pausePanel != null)
        {
            pausePanel.gameObject.SetActive(true);
            UIScreen.Focus(pausePanel);
            Cursor.lockState = CursorLockMode.None;

        }
    }

    public void ShowTryAgainPanel()
    {
        Debug.Log("ShowTryAgainPanel called");
        if (tryAgainPanel != null)
        {
            tryAgainPanel.gameObject.SetActive(true);
            UIScreen.Focus(tryAgainPanel);
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("TryAgainPanel is now active");
        }
        else
        {
            Debug.Log("TryAgainPanel is null");
        }
    }

    public void ShowEndGamePanel()
    {
        Debug.Log("EndGamePanel called");
        if (endGamePanel != null)
        {
            endGamePanel.gameObject.SetActive(true);
            UIScreen.Focus(endGamePanel);
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("EndGamePanel is now active");
        }
        else
        {
            Debug.Log("EndGamePanel is null");
        }
    }

}
