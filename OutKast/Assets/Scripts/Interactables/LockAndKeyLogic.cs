using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAndKeyLogic : MonoBehaviour
{
    KeyPickUpLogic keyPickUpLogic;
    public GameObject lockedDoor;

    void Start()
    {
        lockedDoor.gameObject.SetActive(true);
        keyPickUpLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<KeyPickUpLogic>();
    }

    void OnTriggerEnter2D (Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player" && keyPickUpLogic.keysHolding > 0)
        {
            lockedDoor.gameObject.SetActive(false);
            keyPickUpLogic.UseKey();
        }
    }
}
