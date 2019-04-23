using UnityEngine;

public class SafeAreaLogic : MonoBehaviour
{
    LightTimer lightTimer;
    public Canvas dialogueCanvas;
    void Start ()
    {
        lightTimer = GameObject.FindGameObjectWithTag("Light").GetComponent<LightTimer>();
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
        }
    }
}
