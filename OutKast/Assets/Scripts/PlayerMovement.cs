using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D playerRB;
	float horizontalInput;
	public float playerSpeed;

    void Start()
    {
		playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		horizontalInput = Input.GetAxis("Horizontal");
		Vector2 playerMovementVector = new Vector2(horizontalInput * playerSpeed, playerRB.velocity.y);
		playerRB.AddForce(playerMovementVector * Time.deltaTime);
    }
}
