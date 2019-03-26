using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float fallingGravityModifier = 2.5f;
    Rigidbody2D playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb.velocity.y < 0)
        {
            playerRb.velocity += Vector2.up * Physics2D.gravity.y * (fallingGravityModifier - 1) * Time.deltaTime;
        }
    }
}
