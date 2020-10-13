using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("01");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ContinueGame()
    {
        //SceneManager.LoadScene("Taso04");
    }

}