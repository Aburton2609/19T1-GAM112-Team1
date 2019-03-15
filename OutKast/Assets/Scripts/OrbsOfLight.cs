using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbsOfLight : MonoBehaviour
{
    LightTimer lightTimer;
    public float timeAdded;

    // Start is called before the first frame update
    void Start()
    {
        lightTimer = GameObject.FindGameObjectWithTag("Light").GetComponent<LightTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            lightTimer.timer += timeAdded;
            gameObject.SetActive(false);
        }

    }
}
