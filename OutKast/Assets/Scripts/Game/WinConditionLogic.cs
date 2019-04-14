using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinConditionLogic : MonoBehaviour
{
    public Canvas loadingScreenCanvas;
    public Text loadingText;
    public Image loadingBar;
    public string nextSceneName;
    public string playerPrefsKeyName;
    public string loadingDisplayString;

    void Start ()
    {
        loadingScreenCanvas.gameObject.SetActive(false);
        loadingText.text = "";
        loadingBar.fillAmount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("LevelCompleted");
        }
    }

    public IEnumerator LevelCompleted ()
    {
        loadingScreenCanvas.gameObject.SetActive(true);
        loadingText.text = loadingDisplayString;
        while (loadingBar.fillAmount < 1)
        {
            loadingBar.fillAmount += 0.01f;
            yield return null;
        }
        PlayerPrefs.SetString(playerPrefsKeyName, "Complete");
        SceneManager.LoadScene(nextSceneName);
    }
}
