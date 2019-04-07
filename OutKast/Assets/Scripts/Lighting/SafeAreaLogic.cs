using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaLogic : MonoBehaviour
{
    LightTimer lightTimer;

    void Start ()
    {
        lightTimer = GameObject.FindGameObjectWithTag("Light").GetComponent<LightTimer>();
    }

    void OnTriggerStay2D (Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            lightTimer.ChangeSafeAreaBoolean(true);
        }
    }

    void OnTriggerExit2D (Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            lightTimer.ChangeSafeAreaBoolean(false);
            lightTimer.ResetLightTimer();
        }
    }
}
