using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpLogic : MonoBehaviour
{
    [HideInInspector]public int keysHolding = 0;

    void OnTriggerEnter2D (Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Key")
        {
            keysHolding++;
            collider2D.gameObject.SetActive(false);
        }
    }

    public void UseKey ()
    {
        keysHolding--;
    }
}
