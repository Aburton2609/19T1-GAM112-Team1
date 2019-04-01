using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLogic : MonoBehaviour
{
    public LightTimer lightTimer;
    public PlayerMovement playerMovement;
    public string currentScene;

    void Start ()
    {
        Time.timeScale = 1;
        playerMovement.enabled = true;
        lightTimer.enabled = true;
    }
    

    void Update ()
    {
        if (lightTimer.timer <= 0)
        {
            Time.timeScale = 0;
            playerMovement.enabled = false;
            lightTimer.enabled = false;
            if (Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene(currentScene);
            }
        }
    }
}
