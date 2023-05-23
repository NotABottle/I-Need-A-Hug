using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyGravity : MonoBehaviour
{
    [Header("Gravity Settings")]
    public float fallMultiplier;
    public float jumpHeight;
    public float timeToJumpApex;

    private Rigidbody2D rb;
    private float gravityMultiplier;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        Vector2 newGravity = new Vector2(0,(-2 * jumpHeight) / (timeToJumpApex * timeToJumpApex));
        rb.gravityScale = (newGravity.y / Physics2D.gravity.y) * gravityMultiplier;
    }

    private void FixedUpdate(){
        if(rb.velocity.y < 0f) gravityMultiplier = fallMultiplier;
        else gravityMultiplier = 1f;
    }
}
