using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public Transform transformEgo;
    public LayerMask whatIsGround;
    [HideInInspector] public bool grounded;
    private bool hasJumped = false;
    float groundCheckRadius = 0.15f;
    public float jumpForce = 100;
    public int jumpsRemaining = 1;
    public float jumpingSpeed = 1.5f;
   
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {        
        if (Input.GetKeyDown(KeyCode.Space))
            hasJumped = true;
        JumpingVelocityCap();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(transformEgo.position, groundCheckRadius, whatIsGround);
        if (grounded && hasJumped)
        {
            Jump();
            hasJumped = false;
        }
        else if (grounded == false && hasJumped && jumpsRemaining > 0)
        {
            Jump();
            hasJumped = false;
            jumpsRemaining--;
        }
        else if (grounded)
        {
            jumpsRemaining = 1;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transformEgo.position, groundCheckRadius);
    }

    void Jump()
    {
        playerRB.AddForce(Vector2.up * jumpForce);
        Debug.Log("is using jump method. force: " + playerRB.velocity.y);
    }


    void JumpingVelocityCap()
    {
        float currentXVelocity = playerRB.velocity.x;
        float cappedJumpingVelocity = Mathf.Min(Mathf.Abs(playerRB.velocity.y), jumpingSpeed) * Mathf.Sign(playerRB.velocity.y);
        playerRB.velocity = new Vector2(currentXVelocity, cappedJumpingVelocity);
    }
}
