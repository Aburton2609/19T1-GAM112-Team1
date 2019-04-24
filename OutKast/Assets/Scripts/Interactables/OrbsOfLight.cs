using UnityEngine;

public class OrbsOfLight : MonoBehaviour
{
    LightTimer lightTimer;
    public float timeAdded;
    public AudioClip pickupSound;
    void Start()
    {
        lightTimer = GameObject.FindGameObjectWithTag("Light").GetComponent<LightTimer>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager.instance.PlaySFX(pickupSound);
            lightTimer.AddToTimer(timeAdded);
            gameObject.SetActive(false);
        }
    }
}
