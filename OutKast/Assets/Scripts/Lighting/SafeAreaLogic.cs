using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SafeAreaLogic : MonoBehaviour
{
    LightTimer lightTimer;
    public Canvas dialogueCanvas;
    public Text textDisplay;
    public string[] sentences;
    public float typingSpeed = 0.03f;
    int index;
    bool sentenceHasFinished;
    bool dialogueHasStarted;
    public Image ArrowImage;


    void Start ()
    {
        lightTimer = GameObject.FindGameObjectWithTag("Light").GetComponent<LightTimer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine("Type");
            dialogueCanvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerStay2D (Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            lightTimer.ChangeSafeAreaBoolean(true);

            if (Input.GetKeyDown(KeyCode.Return) && dialogueHasStarted == false)
            {
                dialogueCanvas.gameObject.SetActive(true);
                StartCoroutine("Type");
            }            
        }
    }

    void OnTriggerExit2D (Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {            
            lightTimer.ChangeSafeAreaBoolean(false);
            lightTimer.ResetLightTimer();
            ResetText();
        }
    }


    IEnumerator Type()
    {
        dialogueHasStarted = true;
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        sentenceHasFinished = true;
    }
    void Update()
    {
        if (sentenceHasFinished)
        {
            ArrowImage.gameObject.SetActive(true);
        }
        else
        {
            ArrowImage.gameObject.SetActive(false);
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
                StopCoroutine("Type");
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
        dialogueHasStarted = false;
        dialogueCanvas.gameObject.SetActive(false);
        StopCoroutine("Type");
        textDisplay.text = "";
        index = 0;
    }
}