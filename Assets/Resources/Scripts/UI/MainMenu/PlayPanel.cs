using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayPanel : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(LoadGameScene);
        exitButton.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        Application.Quit();
    }
    private void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
