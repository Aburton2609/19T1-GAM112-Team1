using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public Transform transformEgo;
    float groundCheckRadius = 0.15f;
    public LayerMask whatIsGround;
    [HideInInspector] public bool grounded;
    bool hasJumped = false;
    public float jumpForce;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }        

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            hasJumped = true;
        }
    }

    void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(transformEgo.position, groundCheckRadius, whatIsGround);
        if (hasJumped && grounded)
        {
            playerRB.AddForce(Vector2.up * jumpForce);
            hasJumped = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transformEgo.position, groundCheckRadius);
    }
}
