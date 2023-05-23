using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyDownDetector : MonoBehaviour
{
    [Header("Down Reset Settings")]
    public float maxTimeAllowedOnGround;

    private bool onGround;
    private float timeSpentOnGround;
    private float timeOfFirstContactWithGround;

    private MonkeyGroundChecker mgc;

    private void Awake(){
        mgc = GetComponent<MonkeyGroundChecker>();
    }

    private void Update(){
        /*
        If the values are not equal
        then this one is out of date
        if this thinks we are not grounded but we are
        then set time of first contact
        */
        if(onGround != mgc.IsGrounded()){
            if(onGround == false){
                timeOfFirstContactWithGround = Time.timeSinceLevelLoad;
            }
            onGround = mgc.IsGrounded();
        }

        if(onGround){
            timeSpentOnGround = Time.timeSinceLevelLoad - timeOfFirstContactWithGround;
        }

        if(timeSpentOnGround >= maxTimeAllowedOnGround) EventManager.TriggerEvent("OnResetLevel",null);
    }
}
