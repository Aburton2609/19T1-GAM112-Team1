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
    public float timeBtwJump = 0.3f;
    float timer = 0;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {        
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
            hasJumped = true;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(transformEgo.position, groundCheckRadius, whatIsGround);
        if (grounded && hasJumped)
        {
            Jump();
            hasJumped = false;
            timer = timeBtwJump;
        }
        else if (grounded == false && hasJumped && jumpsRemaining > 0 && timer <= 0)
        {
            Jump();           
            hasJumped = false;
            jumpsRemaining--;
        }
        else if (grounded)
        {
            jumpsRemaining = 1;
        }
        if (grounded == false && timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transformEgo.position, groundCheckRadius);
    }

    void Jump()
    {
        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpingSpeed);        
    }
   
}
