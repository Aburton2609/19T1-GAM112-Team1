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
    public Canvas loadingScreenCanvas;
    public Text loadingText;
    public Image loadingBar;

    private void Start()
    {
        playQuitCanvas.gameObject.SetActive(true);
        levelSelectionCanvas.gameObject.SetActive(false);
        loadingScreenCanvas.gameObject.SetActive(false);
        loadingText.text = "";
        loadingBar.fillAmount = 0;

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
        StartCoroutine(LoadLevel(1));
    }

    public void LoadLevelTwo()
    {
        if (PlayerPrefs.GetString("LevelOneCompletionStatus") == "Complete")
        {
            StartCoroutine(LoadLevel(2));
        }             
    }

    public void LoadLevelThree()
    {
        if (PlayerPrefs.GetString("LevelTwoCompletionStatus") == "Complete")
        {
            StartCoroutine(LoadLevel(3));
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

    IEnumerator LoadLevel (int levelNumber)
    {
        loadingScreenCanvas.gameObject.SetActive(true);
        loadingText.text = "Loading Level " + levelNumber;
        while (loadingBar.fillAmount < 1)
        {
            loadingBar.fillAmount += 0.01f;
            yield return null;
        }
        SceneManager.LoadScene(sceneNames[levelNumber - 1]);
    }
}
