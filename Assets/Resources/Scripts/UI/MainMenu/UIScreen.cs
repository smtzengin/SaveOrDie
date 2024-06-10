using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    public bool isModal = false;
    [SerializeField] private UIScreen previousScreen = null;

    public static UIScreen activeScreen;

    public static void Focus(UIScreen screen)
    {
        if (screen == activeScreen)
            return;

        if (activeScreen)
            activeScreen.Defocus();
        screen.previousScreen = activeScreen;
        activeScreen = screen;
        screen.Focus();
    }

    public static void BackToInitial()
    {
        activeScreen?.BackTo(null);
    }

    public void FocusScreen(UIScreen screen)
    {
        Focus(screen);
    }

    private void Focus()
    {
        if (gameObject)
            gameObject.SetActive(true);
    }

    public void Defocus()
    {
        if (gameObject)
            gameObject.SetActive(false);
        previousScreen = null; 
    }

    public void Back()
    {
        if (previousScreen)
        {
            Defocus();
            UIScreen previous = previousScreen;
            activeScreen = previousScreen;
            previousScreen = previous.previousScreen;
            activeScreen.Focus();
        }
    }

    public void BackTo(UIScreen screen)
    {
        while (activeScreen != null && activeScreen.previousScreen != null && activeScreen != screen)
            activeScreen.Back();
    }
}
