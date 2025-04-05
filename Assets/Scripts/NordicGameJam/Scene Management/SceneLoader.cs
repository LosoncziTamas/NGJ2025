using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void MenuReturn()
    {
        SceneManager.LoadScene("");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("ObstacleTest");
    }

    public void exitGame()
    {
        SceneManager.LoadScene("");
    }
        
}
