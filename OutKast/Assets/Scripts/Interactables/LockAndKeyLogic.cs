using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAndKeyLogic : MonoBehaviour
{    
    public bool haskey;
    public GameObject lockedDoor;

    void Start()
    {
        lockedDoor.gameObject.SetActive(true);
        haskey = false;
    }

    void OnTriggerEnter2D (Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player" && haskey == true)
        {
            lockedDoor.gameObject.SetActive(false);
        }
    }
}
