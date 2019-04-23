using UnityEngine;

public class AnimatorInputLogic : MonoBehaviour
{
    Animator playerAnim;
    PlayerJump playerJump;
    public Transform wallCheckTransform;
    public LayerMask whatIsGround;
    bool isAbleToWalk;


    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerJump = GetComponent<PlayerJump>();
    }


    void Update()
    {
        isAbleToWalk = Physics2D.OverlapCircle(wallCheckTransform.position, 0.15f, whatIsGround);
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (isAbleToWalk && horizontalInput > 0 && transform.localScale.x > 0)
        {
            horizontalInput = 0;
        }
        else if (isAbleToWalk && horizontalInput < 0 && transform.localScale.x < 0)
        {
            horizontalInput = 0;
        }
        horizontalInput = Mathf.Abs(horizontalInput);
        playerAnim.SetFloat("horizontalInput", horizontalInput);

        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        playerAnim.SetBool("isSprinting", isShiftPressed);

        playerAnim.SetBool("isJumping", !playerJump.grounded);
    }         
}
