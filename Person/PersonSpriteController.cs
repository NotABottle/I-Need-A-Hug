using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpriteController : MonoBehaviour
{
    private Animator animator;

    private PersonStateController psc;

    private void OnEnable(){
        EventManager.StartListening("OnMonkeyLaunch",ChangeToIdle);
        EventManager.StartListening("OnMonkeyHug",listener: ChangeToHugging);
    }

    private void OnDisable(){
        EventManager.StopListening("OnMonkeyLaunch",ChangeToIdle);
        EventManager.StopListening("OnMonkeyHug",listener: ChangeToHugging);
    }

    private void ChangeToHugging(Dictionary<string, object> dictionary)
    {
        var hugRecipient = (PersonStateController) dictionary["PersonStateController"];
        
        if(hugRecipient != psc) return;

        animator.SetBool("Hugging", true);
    }

    private void ChangeToIdle(Dictionary<string, object> dictionary)
    {
        animator.SetBool("Hugging", false);
    }

    private void Awake(){
        animator = GetComponent<Animator>();
        psc = GetComponentInParent<PersonStateController>();
    }
}
