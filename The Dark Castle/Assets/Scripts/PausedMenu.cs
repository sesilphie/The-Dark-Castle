using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    
    //public void Pause()
    //{
    //    PauseMenu.SetActive(true);
    //    Time.timeScale = 0f;
    //}
    public void Continue()
    {
        GameState.Instance.CurrentState = GameState.States.Playing;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}