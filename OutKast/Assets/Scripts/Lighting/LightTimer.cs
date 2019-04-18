using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTimer : MonoBehaviour
{    
    public float startTimer = 10;
    public float walkingDecayMuliplier = 2;
    public float RunningDecayMultiplier = 4;
    public float startingSpriteSizeMultipliedByTimer = 1;
    [HideInInspector] public float timer;
    bool inSafeArea;
    public Transform wallCheckTransform;
    public LayerMask whatIsGround;
    bool notAbleToWalk;

    void Start()
    {
        inSafeArea = false;
        ResetLightTimer();
    }

    void Update()
    {
        notAbleToWalk = Physics2D.OverlapCircle(wallCheckTransform.position,0.15f, whatIsGround);
        gameObject.transform.localScale = new Vector3(timer * startingSpriteSizeMultipliedByTimer, timer * startingSpriteSizeMultipliedByTimer, 0);
        bool isWalkingLeft = Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftArrow);
        bool isWalkingRight = Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.RightArrow);
        bool isRunning = (Input.GetKey(KeyCode.LeftShift) && (isWalkingLeft || isWalkingRight));

        if (inSafeArea == false)
        {
            if ((isWalkingLeft || isWalkingRight) && notAbleToWalk == false)
            {
                timer -= (Time.deltaTime * walkingDecayMuliplier);
            }
            else if (isRunning && notAbleToWalk == false)
            {
                timer -= (Time.deltaTime * RunningDecayMultiplier);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
   

    public void AddToTimer(float timeToAdd)
    {
        timer += timeToAdd;
    }

    public void ChangeSafeAreaBoolean (bool value)
    {
        inSafeArea = value;
    }

    public void ResetLightTimer()
    {
        timer = startTimer;
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(wallCheckTransform.position,0.15f);
    }
}
