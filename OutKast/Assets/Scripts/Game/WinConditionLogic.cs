using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionLogic : MonoBehaviour
{
    public string nextSceneName;
    public string playerPrefsKeyName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelCompleted();
        }
    }

    public void LevelCompleted ()
    {
        PlayerPrefs.SetString(playerPrefsKeyName, "Complete");
        SceneManager.LoadScene(nextSceneName);
    }
}
