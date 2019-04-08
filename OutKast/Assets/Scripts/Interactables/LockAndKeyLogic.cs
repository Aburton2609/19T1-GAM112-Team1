using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockAndKeyLogic : MonoBehaviour
{
    KeyPickUpLogic keyPickUpLogic;
    public GameObject lockedDoor;
    Image keysHoldingUI;

    void Start()
    {
        keysHoldingUI = GameObject.FindGameObjectWithTag("KeyImage").GetComponent<Image>();
        lockedDoor.gameObject.SetActive(true);
        keyPickUpLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<KeyPickUpLogic>();
    }

    void OnTriggerEnter2D (Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player" && keysHoldingUI.fillAmount > 0)
        {
            lockedDoor.gameObject.SetActive(false);
            keyPickUpLogic.UseKey();
        }
    }
}
