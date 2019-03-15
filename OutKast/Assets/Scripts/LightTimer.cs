using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTimer : MonoBehaviour
{
    
    
    public float startTimer = 10;
    public float walkingDecayMuliplier = 2;
    public float RunningDecayMultiplier = 6;
    public float startingSizeMultipliedByTimer = 1;
    [HideInInspector] public float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = startTimer;    
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.localScale = new Vector3(timer * startingSizeMultipliedByTimer, timer * startingSizeMultipliedByTimer, 0);
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
