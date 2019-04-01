using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorInputLogic : MonoBehaviour
{
    Animator playerAnim;
    PlayerJump playerJump;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerJump = GetComponent<PlayerJump>();
    }


    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        horizontalInput = Mathf.Abs(horizontalInput);
        playerAnim.SetFloat("horizontalInput", horizontalInput);

        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);
        playerAnim.SetBool("isSprinting", isShiftPressed);

        playerAnim.SetBool("isJumping", !playerJump.grounded);
    }
}
