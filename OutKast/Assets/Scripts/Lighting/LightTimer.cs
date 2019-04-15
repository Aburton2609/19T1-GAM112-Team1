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

    void Start()
    {
        inSafeArea = false;
        ResetLightTimer();
    }

    void Update()
    {        
        gameObject.transform.localScale = new Vector3(timer * startingSpriteSizeMultipliedByTimer, timer * startingSpriteSizeMultipliedByTimer, 0);
        bool isWalkingLeft = Input.GetKey(KeyCode.A);
        bool isWalkingRight = Input.GetKey(KeyCode.D);
        bool isRunning = (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)));

        if (inSafeArea == false)
        {
            if (isWalkingLeft || isWalkingRight)
            {
                timer -= (Time.deltaTime * walkingDecayMuliplier);
            }
            else if (isRunning)
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
}
