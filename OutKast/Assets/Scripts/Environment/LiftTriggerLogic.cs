using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftTriggerLogic : MonoBehaviour
{
    public LiftLogic liftLogic;

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            liftLogic.MoveToBottomTarget();
        }
    }
}
