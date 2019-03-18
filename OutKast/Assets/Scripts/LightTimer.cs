using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTimer : MonoBehaviour
{    
    public float startTimer = 10;
    public float walkingDecayMuliplier = 2;
    public float RunningDecayMultiplier = 6;
    public float startingSpriteSizeMultipliedByTimer = 1;
    [HideInInspector] public float timer;
    public Light playerPointLight;
    public float startingLightRangeMultipliedByTimer = 2;

    void Start()
    {
        timer = startTimer;
    }

    void Update()
    {        
        gameObject.transform.localScale = new Vector3(timer * startingSpriteSizeMultipliedByTimer, timer * startingSpriteSizeMultipliedByTimer, 0);
        playerPointLight.range = timer * startingLightRangeMultipliedByTimer;
        bool isWalkingLeft = Input.GetKey(KeyCode.A);
        bool isWalkingRight = Input.GetKey(KeyCode.D);
        bool isRunning = (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)));
        if (isWalkingLeft || isWalkingRight)
        {
            timer -= (Time.deltaTime * walkingDecayMuliplier);
        }
        if (isRunning)
        {
            timer -= (Time.deltaTime * RunningDecayMultiplier);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
