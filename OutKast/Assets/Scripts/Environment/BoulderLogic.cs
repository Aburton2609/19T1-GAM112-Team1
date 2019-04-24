using System.Collections;
using UnityEngine;

public class BoulderLogic : MonoBehaviour
{
    public GameObject boulder;
    public float timeDelay = 0.5f;
    public float shakeAmount = 0.1f;
    Vector3 originalPosition;
    private AudioSource source;

    void Start ()
    {
        originalPosition = boulder.transform.position;
        source = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("DelayBoulderFalling");
        }
    }

    IEnumerator DelayBoulderFalling ()
    {
        InvokeRepeating("BeginShake", 0, 0.01f);
        yield return new WaitForSeconds(timeDelay);
        source.Play(0);
        boulder.AddComponent<Rigidbody2D>();
        Invoke("StopShake",0);
        gameObject.SetActive(false);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {

            Vector3 newPosition = boulder.transform.position;
            float shakeAmountX = Random.value * shakeAmount * 2 - shakeAmount;
            float shakeAmountY = Random.value * shakeAmount * 2 - shakeAmount;
            newPosition.x += shakeAmountX;
            newPosition.y += shakeAmountY;
            boulder.transform.position = newPosition;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        boulder.transform.position = originalPosition;
    }
}
