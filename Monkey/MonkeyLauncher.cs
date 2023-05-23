using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyLauncher : MonoBehaviour
{
    [Header("Launcher Settings")]
    public float pullDistanceToAchieveMaxSpeed;
    public float maxLaunchSpeed;

    public float normalizedPullDistance {get; private set;}
    public Vector2 pullDirection {get; private set;}

    [Header("Components")]
    private MonkeyStateController msc;
    private Rigidbody2D rb;
    private Camera cam;

    private void Awake(){
        msc = GetComponent<MonkeyStateController>();
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void OnMouseDown(){
        Debug.Log("Monkey Selected");
    }

    private void OnMouseDrag(){
        CalculateLaunchValues();
    }

    private void OnMouseUp(){
        if(msc.monkeyState == MonkeyState.Hugging) LaunchMonkey();
    }

    private void LaunchMonkey()
    {
        EventManager.TriggerEvent("OnMonkeyLaunch",null);
        EventManager.TriggerEvent("playSound",new Dictionary<string, object> {{"soundName", "Launch"}});
        rb.velocity = -pullDirection * normalizedPullDistance * maxLaunchSpeed;
    }

    private void CalculateLaunchValues()
    {
        Vector2 currentMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        float pullDistance = Vector2.Distance(transform.position,currentMousePosition);

        normalizedPullDistance = (Mathf.Clamp(pullDistance,0f,pullDistanceToAchieveMaxSpeed))/pullDistanceToAchieveMaxSpeed;
        
        pullDirection = (currentMousePosition - (Vector2)transform.position).normalized;
    }

}
