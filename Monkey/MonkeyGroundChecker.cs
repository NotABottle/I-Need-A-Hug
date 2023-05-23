using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyGroundChecker : MonoBehaviour
{
    [Header("Ground Checker Settings")]
    public float groundDistance;
    public LayerMask groundMask;

    private bool grounded;

    private MonkeyStateController msc;

    private void Awake() => msc = GetComponent<MonkeyStateController>();

    private void Update()
    {
        if(msc.monkeyState == MonkeyState.Flying) CheckIfMonkeyIsOnGround();
    }

    private void CheckIfMonkeyIsOnGround()
    {
        //Fire a ray downwards, if it hits the ground, set grounded to true
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundMask);
        if (hit.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    public bool IsGrounded(){
        return grounded;
    }

}
