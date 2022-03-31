using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    
    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void LoadScene(int levelNo)
    {
        SceneManager.LoadScene(levelNo);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
