using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGamePanelUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
            Destroy(UIManager.Instance.gameObject);
        });
    }
}
