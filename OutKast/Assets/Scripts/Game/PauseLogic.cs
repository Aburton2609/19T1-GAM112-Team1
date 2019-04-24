using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour
{
    public Canvas pauseCanvas;
    public string sceneName;
    public AudioClip buttonClickSFX;
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
        Time.timeScale = 0;
        pauseCanvas.gameObject.SetActive(true);
        isPaused = true;
        SoundManager.instance.PlaySFX(buttonClickSFX);
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
        isPaused = false;
        SoundManager.instance.PlaySFX(buttonClickSFX);
    }

    public void ReturnToMainMenu ()
    {
        SoundManager.instance.PlaySFX(buttonClickSFX);
        SceneManager.LoadScene(sceneName);
    }
}
