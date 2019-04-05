using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderLogic : MonoBehaviour
{
    public GameObject boulder;
    public float timeDelay = 0.5f;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("DelayBoulderFalling");
        }
    }

    IEnumerator DelayBoulderFalling ()
    {
        yield return new WaitForSeconds(timeDelay);
        boulder.AddComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }
}
