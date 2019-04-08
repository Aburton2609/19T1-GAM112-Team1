using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbsOfLight : MonoBehaviour
{
    LightTimer lightTimer;
    public float timeAdded;

    void Start()
    {
        lightTimer = GameObject.FindGameObjectWithTag("Light").GetComponent<LightTimer>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            lightTimer.AddToTimer(timeAdded);
            gameObject.SetActive(false);
        }
    }
}
