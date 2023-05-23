using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySpriteController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private void OnEnable(){
        EventManager.StartListening("OnMonkeyLaunch",ChangeToFlying);
        EventManager.StartListening("OnMonkeyHug",listener: ChangeToHugging);
    }

    private void OnDisable(){
        EventManager.StopListening("OnMonkeyLaunch",ChangeToFlying);
        EventManager.StopListening("OnMonkeyHug",listener: ChangeToHugging);
    }

    private void ChangeToHugging(Dictionary<string, object> dictionary)
    {
        animator.SetBool("Hugging", true);
    }

    private void ChangeToFlying(Dictionary<string, object> dictionary)
    {
        animator.SetBool("Hugging",false);
    }

    private void Awake(){
        rb = GetComponentInParent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
}
