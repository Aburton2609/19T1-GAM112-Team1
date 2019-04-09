using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    public string[] sceneNames;
    public Canvas playQuitCanvas;
    public Canvas levelSelectionCanvas;
    public Button[] levelSelectionsButtons;

    private void Start()
    {
        playQuitCanvas.gameObject.SetActive(true);
        levelSelectionCanvas.gameObject.SetActive(false);

        if (PlayerPrefs.GetString("LevelThreeCompletionStatus") == "Complete")
        {
            levelSelectionsButtons[0].GetComponent<Image>().color = Color.green;
            levelSelectionsButtons[1].GetComponent<Image>().color = Color.green;
            levelSelectionsButtons[2].GetComponent<Image>().color = Color.green;
        }
        else if (PlayerPrefs.GetString("LevelTwoCompletionStatus") == "Complete")
        {
            levelSelectionsButtons[0].GetComponent<Image>().color = Color.green;
            levelSelectionsButtons[1].GetComponent<Image>().color = Color.green;
            levelSelectionsButtons[2].GetComponent<Image>().color = Color.white;
        }
        else if (PlayerPrefs.GetString("LevelOneCompletionStatus") == "Complete")
        {
            levelSelectionsButtons[0].GetComponent<Image>().color = Color.green;
            levelSelectionsButtons[1].GetComponent<Image>().color = Color.white;
            levelSelectionsButtons[2].GetComponent<Image>().color = Color.grey;
        }
        else
        {
            levelSelectionsButtons[0].GetComponent<Image>().color = Color.white;
            levelSelectionsButtons[1].GetComponent<Image>().color = Color.grey;
            levelSelectionsButtons[2].GetComponent<Image>().color = Color.grey;
        }        
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
        if (PlayerPrefs.GetString("LevelOneCompletionStatus") == "Complete")
        {
            SceneManager.LoadScene(sceneNames[1]);
        }             
    }

    public void LoadLevelThree()
    {
        if (PlayerPrefs.GetString("LevelTwoCompletionStatus") == "Complete")
        {
            SceneManager.LoadScene(sceneNames[2]);
        }
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
