using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public UIScreen playPanel;


    private void Start()
    {
        // İlk ekrana odaklan
        UIScreen.Focus(playPanel);
    }

}
