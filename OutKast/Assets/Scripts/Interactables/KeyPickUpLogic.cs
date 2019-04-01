using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpLogic : MonoBehaviour
{
    public LockAndKeyLogic lockAndKeyLogic;

    void OnTriggerEnter2D (Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            lockAndKeyLogic.haskey = true;
            gameObject.SetActive(false);
        }
    }
}
