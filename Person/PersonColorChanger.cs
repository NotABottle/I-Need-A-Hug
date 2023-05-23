using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonColorChanger : MonoBehaviour
{
    private PersonStateController psc;
    private SpriteRenderer spriteRenderer;

    private void OnEnable() => EventManager.StartListening("OnPersonStateChange", ChangeColor);

    private void Awake(){
        psc = GetComponent<PersonStateController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void ChangeColor(Dictionary<string, object> dictionary)
    {
        var personBeingChanged = (PersonStateController) dictionary["PersonStateController"];
        var newState = (PersonState) dictionary["NewState"];
        if(personBeingChanged != psc) return;
        switch(newState){
            case PersonState.NeedHug:
                ChangeSpriteColor(Color.red);
                break;
            case PersonState.BeingHugged:
                ChangeSpriteColor(Color.yellow);
                break;
            case PersonState.HadHug:
                ChangeSpriteColor(Color.green);
                break;
        }
    }

    private void ChangeSpriteColor(Color newColor){
        spriteRenderer.color = newColor;
    }
}
