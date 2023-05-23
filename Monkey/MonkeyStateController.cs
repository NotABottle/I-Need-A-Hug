using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyStateController : MonoBehaviour
{
    [SerializeField]
    public MonkeyState monkeyState = MonkeyState.Flying;

    private void OnEnable(){
        EventManager.StartListening("OnMonkeyHug",StartHug);
        EventManager.StartListening("OnMonkeyLaunch",StopHug);
    }

    private void OnDisable(){
        EventManager.StopListening("OnMonkeyHug",StartHug);
        EventManager.StopListening("OnMonkeyLaunch",StopHug);
    }
    private void SwitchState(MonkeyState newState){
        switch(newState){
            case MonkeyState.Hugging:
                HandleHuggingState();
                break;
            case MonkeyState.Flying:
                HandleFlyingState();
                break;
        }
    }

    private void HandleHuggingState()
    {
        monkeyState = MonkeyState.Hugging;
    }

    private void HandleFlyingState()
    {
        monkeyState = MonkeyState.Flying;
    }

    private void StartHug(Dictionary<string, object> dictionary)
    {
        SwitchState(MonkeyState.Hugging);
    }

    private void StopHug(Dictionary<string, object> dictionary)
    {
        SwitchState(MonkeyState.Flying);
    }
}

[Serializable]
public enum MonkeyState{
    Hugging,
    Flying
}
