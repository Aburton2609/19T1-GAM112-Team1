using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour
{
    public Canvas pauseCanvas;
    public string sceneName;
    bool isPaused;
    void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (isPaused == false && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();           
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
    }

    void PauseGame ()
    {
        if (isPaused == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseCanvas.gameObject.SetActive(true);
            isPaused = true;
        }
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
        isPaused = false;
    }

    public void ReturnToMainMenu ()
    {
        SceneManager.LoadScene(sceneName);
    }
}
