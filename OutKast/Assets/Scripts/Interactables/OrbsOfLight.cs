using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OrbsOfLight : MonoBehaviour
{
    LightTimer lightTimer;
    public float timeAdded;
    private AudioSource source;

    void Start()
    {
        lightTimer = GameObject.FindGameObjectWithTag("Light").GetComponent<LightTimer>();
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.Play(0);
            lightTimer.AddToTimer(timeAdded);
            gameObject.SetActive(false);
        }
    }
}
