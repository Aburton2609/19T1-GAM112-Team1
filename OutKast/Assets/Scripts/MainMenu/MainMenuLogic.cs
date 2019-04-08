using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public string[] sceneNames;
    public Canvas playQuitCanvas;
    public Canvas levelSelectionCanvas;

    private void Start()
    {
        playQuitCanvas.gameObject.SetActive(true);
        levelSelectionCanvas.gameObject.SetActive(false);
    }

    public void PlayGame ()
    {
        playQuitCanvas.gameObject.SetActive(false);
        levelSelectionCanvas.gameObject.SetActive(true);
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(sceneNames[0]);
    }

    public void LoadLevelTwo()
    {        

         SceneManager.LoadScene(sceneNames[1]);        
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene(sceneNames[2]);
    }

    public void Return ()
    {
        playQuitCanvas.gameObject.SetActive(true);
        levelSelectionCanvas.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();            
    }
}
