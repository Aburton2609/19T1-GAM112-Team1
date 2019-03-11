using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D playerRB;
	private float horizontalInput;
	private float playerSpeed;

    void Start()
    {
		playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		horizontalInput = Input.GetAxis("Horizontal");
		playerRB.AddForce(new Vector2(horizontalInput * playerSpeed * Time.deltaTime, playerRB.velocity.y));
<<<<<<< HEAD
    }
=======
    }   
>>>>>>> adf84c0863db31e279f481b3370adf592b98bb14
}
