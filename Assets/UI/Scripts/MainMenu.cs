using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //public string sceneName = "Scene01";

    public void PlayGame()
    {
        //SceneManager.LoadScene(sceneName);  GEREKİRSE 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
