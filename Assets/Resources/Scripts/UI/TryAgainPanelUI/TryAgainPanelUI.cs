using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TryAgainPanelUI : MonoBehaviour
{
    [SerializeField] private Button tryAgainButton;
    private void Start()
    {
        tryAgainButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                Destroy(UIManager.Instance.gameObject);
            }
        });
    }
}
