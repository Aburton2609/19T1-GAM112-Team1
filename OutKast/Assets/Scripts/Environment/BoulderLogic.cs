using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderLogic : MonoBehaviour
{
    public GameObject boulder;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            boulder.AddComponent<Rigidbody2D>();
            gameObject.SetActive(false);
        }
    }
}
