using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyTrajectoryRenderer : MonoBehaviour
{
    [Header("Launch Trajectory Settings")]
    public int linePoints;
    public float timeBetweenPoints;

    private MonkeyStateController msc;
    private MonkeyLauncher monkeyLauncher;
    private LineRenderer lineRenderer;
    private Rigidbody2D rb;

    private void OnEnable() => EventManager.StartListening("OnMonkeyLaunch",DisableTrajectory);
    private void OnDisable() => EventManager.StopListening("OnMonkeyLaunch",DisableTrajectory);

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        monkeyLauncher = GetComponent<MonkeyLauncher>();
        msc = GetComponent<MonkeyStateController>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnMouseDrag(){
        if(msc.monkeyState == MonkeyState.Hugging) RenderLaunchTrajectory();
    }

    private void RenderLaunchTrajectory()
    {
        var pullDirection = monkeyLauncher.pullDirection;
        var normalizedPullDistance = monkeyLauncher.normalizedPullDistance;
        var maxLaunchSpeed = monkeyLauncher.maxLaunchSpeed;

        var initialPosition = transform.position;
        var initialVelocity = -pullDirection * normalizedPullDistance * maxLaunchSpeed;
        var angleOfLaunch = Vector2.Angle(transform.right,-pullDirection);

        lineRenderer.enabled = true;
        lineRenderer.positionCount = Mathf.CeilToInt(linePoints/timeBetweenPoints) + 1;
        int i = 0;
        lineRenderer.SetPosition(i,initialPosition);
        for(float time = 0; time < linePoints; time += timeBetweenPoints){
            i++;
            Vector2 point = (Vector2)initialPosition + time * initialVelocity;
            point.y = initialPosition.y + initialVelocity.y * time + (Physics2D.gravity.y * rb.gravityScale / 2f * time * time);

            lineRenderer.SetPosition(i,point);

        }
    }

    private void DisableTrajectory(Dictionary<string, object> dictionary)
    {
        lineRenderer.enabled = false;
    }

}
