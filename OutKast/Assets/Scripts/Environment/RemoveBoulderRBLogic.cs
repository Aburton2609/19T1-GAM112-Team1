using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBoulderRBLogic : MonoBehaviour
{
    GameOverLogic gameOverLogic;
    public int objectsToDestroy = 0;

    void Start ()
    {
        gameOverLogic = GameObject.Find("Game Scene Manager").GetComponent<GameOverLogic>();
    }
   void OnCollisionEnter2D (Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player" && gameObject.GetComponent<Rigidbody2D>())
        {
            gameOverLogic.RestartLevel();
        }
        else if (collision2D.gameObject.tag == "Platform" && objectsToDestroy > 0)
        {
            Destroy(collision2D.gameObject);
            objectsToDestroy--;
        }
        else
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
    }
}
