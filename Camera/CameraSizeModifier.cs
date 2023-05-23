using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeModifier : MonoBehaviour
{
    public float minY;
    public float maxY;
    public float minSize;
    public float maxSize;
    public float lineLength;

    [SerializeField]
    private float yValueOfPlayer;
    [SerializeField]
    private float newCameraSize;

    private Transform player;
    private Cinemachine.CinemachineVirtualCamera virtualCamera;

    private void Awake(){
        player = GameObject.Find("Monkey").transform;
        virtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    private void Update(){
        yValueOfPlayer = player.position.y;

        newCameraSize = ((yValueOfPlayer - minY)/(maxY - minY)) * (maxSize - minSize) + minSize;

        newCameraSize = Mathf.Clamp(newCameraSize,minSize,maxSize);

        virtualCamera.m_Lens.OrthographicSize = newCameraSize;

    }

    [ExecuteAlways]
    private void OnDrawGizmos(){
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(Vector2.up * minY,Vector2.up * minY + Vector2.right * lineLength);
        Gizmos.DrawLine(Vector2.up * minY,Vector2.up * minY + Vector2.right * -lineLength);

        Gizmos.DrawLine(Vector2.up * maxY,Vector2.up * maxY + Vector2.right * lineLength);
        Gizmos.DrawLine(Vector2.up * maxY,Vector2.up * maxY + Vector2.right * -lineLength);
    }
}
