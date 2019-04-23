using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SafeAreaLogic : MonoBehaviour
{
    LightTimer lightTimer;
    public Canvas dialogueCanvas;
    public Text textDisplay;
    public float typingSpeed = 0.01f;
    public string[] sentences;
    bool sentenceHasFinished;
    int index;
    public Image arrowImage;

    void Start ()
    {
        lightTimer = GameObject.FindGameObjectWithTag("Light").GetComponent<LightTimer>();
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            StartCoroutine("Type");
        }
    }

    void OnTriggerStay2D (Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            lightTimer.ChangeSafeAreaBoolean(true);
            dialogueCanvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D (Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            dialogueCanvas.gameObject.SetActive(false);
            lightTimer.ChangeSafeAreaBoolean(false);
            lightTimer.ResetLightTimer();
            ResetText();
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        sentenceHasFinished = true;
    }
        
    void Update ()
    {
        if (sentenceHasFinished)
        {
            arrowImage.gameObject.SetActive(true);
        }
        else
        {
            arrowImage.gameObject.SetActive(false);
        }
        NextSentence();
    }

    void NextSentence()
    {
        if (Input.GetKeyDown(KeyCode.Return) && sentenceHasFinished)
        {
            sentenceHasFinished = false;
            if (index < sentences.Length - 1)
            {
                index++;
                textDisplay.text = "";
                StartCoroutine("Type");
            }
            else
            {
                ResetText();
            }
        }
    }

    void ResetText()
    {
        StopCoroutine("Type");
        textDisplay.text = "";
        index = 0;
    }
}
