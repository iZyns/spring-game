using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup OptionPanel;
    public CanvasGroup CreditPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Option()
    {
        OptionPanel.alpha = 1;
        OptionPanel.blocksRaycasts = true;
    }

    public void Back()
    {
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
    }

    public void Credits()
    {
        CreditPanel.alpha = 1;
        CreditPanel.blocksRaycasts = true;
    }

    public void BackCredit()
    {
        CreditPanel.alpha = 0;
        CreditPanel.blocksRaycasts = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
