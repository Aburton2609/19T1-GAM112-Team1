using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D playerRB;
    PlayerJump playerJump;
	private float horizontalInput;
	private float horizontalForce = 1000;
    [Range(1,10)]public float walkingSpeed;
    [Range(1,10)]public float runningSpeed;
    private bool isRunning = false;
    float xScale;
    public Vector2 currentSpeeds;

    void Start()
	{
		playerRB = GetComponent<Rigidbody2D>();
        playerJump = GetComponent<PlayerJump>();
        xScale = gameObject.transform.localScale.x;
    }

	void Update()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
        Flip(horizontalInput);
        playerRB.AddForce(new Vector2(horizontalInput * horizontalForce * Time.deltaTime, playerRB.velocity.y));

        if (Input.GetKeyDown(KeyCode.LeftShift) && playerJump.grounded == true)
        {
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
        if (isRunning)
        {
            RunningVelocityCap();
        }
        else if (isRunning == false)
        {
            WalkingVelocityCap();
        }
        currentSpeeds = playerRB.velocity;
    }

    void WalkingVelocityCap()
    {
        float cappedWalkingVelocity = Mathf.Min(Mathf.Abs(playerRB.velocity.x), walkingSpeed) * Mathf.Sign(playerRB.velocity.x);
        float currentYVelocity = playerRB.velocity.y;
        playerRB.velocity = new Vector3(cappedWalkingVelocity, currentYVelocity, 0);
    }
    void RunningVelocityCap()
    {
        float cappedRunningVelocity = Mathf.Min(Mathf.Abs(playerRB.velocity.x), runningSpeed) * Mathf.Sign(playerRB.velocity.x);
        float currentYVelocity = playerRB.velocity.y;
        playerRB.velocity = new Vector3(cappedRunningVelocity, currentYVelocity, 0);
    }

    void Flip(float input)
    {
        if (input < 0)
        {
            gameObject.transform.localScale = new Vector3(-xScale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        if (input > 0)
        {
            gameObject.transform.localScale = new Vector3(xScale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }

    }
}