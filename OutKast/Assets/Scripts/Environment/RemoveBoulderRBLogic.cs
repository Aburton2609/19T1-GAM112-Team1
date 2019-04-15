using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBoulderRBLogic : MonoBehaviour
{
    GameOverLogic gameOverLogic;

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
        else
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
    }
}
