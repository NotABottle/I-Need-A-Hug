using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndOfLevel : MonoBehaviour
{
    public BoxCollider2D boxCollider;

    private void OnTriggerEnter2D(Collider2D coll){
        EventManager.TriggerEvent("OnReachEndOfLevel",null);
    }

    [ExecuteAlways]
    private void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position,boxCollider.bounds.size);
    }
}
