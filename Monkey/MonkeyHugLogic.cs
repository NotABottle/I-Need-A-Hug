using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyHugLogic : MonoBehaviour
{
    public float lerpTime;

    private PersonStateController hugRecipient;

    private MonkeyStateController msc;
    private Rigidbody2D rb;

    private void OnEnable(){
        EventManager.StartListening("OnMonkeyHug",StartHug);
        EventManager.StartListening("OnMonkeyLaunch",StopHug);
    }

    private void OnDisable(){
        EventManager.StopListening("OnMonkeyHug",StartHug);
        EventManager.StopListening("OnMonkeyLaunch",StopHug);
    }

    private void Awake(){
        msc = GetComponent<MonkeyStateController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if(msc.monkeyState == MonkeyState.Hugging){
            SnapToCurrentlyHuggedPerson();
        }
    }

    private void SnapToCurrentlyHuggedPerson()
    {
        transform.position = Vector2.Lerp(transform.position,hugRecipient.transform.position,lerpTime * Time.deltaTime);
    }

    private void StartHug(Dictionary<string, object> dictionary)
    {
        hugRecipient = (PersonStateController) dictionary["PersonStateController"];
        EventManager.TriggerEvent("playSound",new Dictionary<string, object> {{"soundName", "Hug"}});
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void StopHug(Dictionary<string, object> dictionary)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
