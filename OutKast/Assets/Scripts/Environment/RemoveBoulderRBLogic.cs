using UnityEngine;

public class RemoveBoulderRBLogic : MonoBehaviour
{
    GameOverLogic gameOverLogic;
    public int objectsToDestroy = 0;
    public AudioClip hurtSFX;
    public AudioClip collisionSFX;
    void Start ()
    {
        gameOverLogic = GameObject.Find("Game Scene Manager").GetComponent<GameOverLogic>();
    }
   void OnCollisionEnter2D (Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player" && gameObject.GetComponent<Rigidbody2D>())
        {
            SoundManager.instance.PlaySFX(hurtSFX);
            gameOverLogic.RestartLevel();
        }
        else if (collision2D.gameObject.tag == "Platform" && objectsToDestroy > 0)
        {
            Destroy(collision2D.gameObject);
            objectsToDestroy--;
            SoundManager.instance.PlaySFX(collisionSFX);
        }
        else
        {
            SoundManager.instance.PlaySFX(collisionSFX);
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
    }
}
