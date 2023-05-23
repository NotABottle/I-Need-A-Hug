using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonStateController : MonoBehaviour
{
    public PersonState personState = PersonState.NeedHug;

    private void OnEnable(){
        EventManager.StartListening("OnMonkeyHug",StartHug);
        EventManager.StartListening("OnMonkeyLaunch",StopHug);
    }

    private void OnDisable(){
        EventManager.StopListening("OnMonkeyHug",StartHug);
        EventManager.StopListening("OnMonkeyLaunch",StopHug);
    }

    private void Awake(){
        InitializePerson();
    }

    private void SwitchState(PersonState newState){
        switch(newState){
            case PersonState.NeedHug:
                HandleNeedHugState();
                break;
            case PersonState.BeingHugged:
                HandleBeingHuggedState();
                break;
            case PersonState.HadHug:
                HandleHadHugState();
                break;
        }
    }

    private void HandleNeedHugState()
    {
        EventManager.TriggerEvent("OnPersonStateChange",new Dictionary<string, object>{{"PersonStateController" ,this} ,{"OldState", personState}, {"NewState",PersonState.NeedHug}});
        personState = PersonState.NeedHug;
    }

    private void HandleBeingHuggedState()
    {
        EventManager.TriggerEvent("OnPersonStateChange",new Dictionary<string, object>{{"PersonStateController" ,this} ,{"OldState", personState}, {"NewState",PersonState.BeingHugged}});
        personState = PersonState.BeingHugged;
    }

    private void HandleHadHugState()
    {
        EventManager.TriggerEvent("OnPersonStateChange",new Dictionary<string, object>{{"PersonStateController" ,this} ,{"OldState", personState}, {"NewState",PersonState.HadHug}});
        personState = PersonState.HadHug;
    }

    public void InitializePerson(){
        SwitchState(PersonState.NeedHug);
    }

    public void StartHug(Dictionary<string, object> dictionary){
        var hugRecipient = (PersonStateController) dictionary["PersonStateController"];
        if(hugRecipient != this) return;

        SwitchState(PersonState.BeingHugged);
    }

    public void StopHug(Dictionary<string, object> dictionary){
        if(personState != PersonState.BeingHugged) return;

        SwitchState(PersonState.HadHug);
    }
}

[System.Serializable]
public enum PersonState{
    NeedHug,
    BeingHugged,
    HadHug
}