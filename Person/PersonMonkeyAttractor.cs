using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMonkeyAttractor : MonoBehaviour
{
    public float attractionDistance;
    
    private Transform player;
    private PersonStateController psc;

    private void Awake(){
        player = GameObject.Find("Monkey").transform;
        psc = GetComponent<PersonStateController>();
    }

    private void Update(){
        var INeedAHug = (psc.personState == PersonState.NeedHug);
        var distanceFromPersonToPlayer = Vector2.Distance(transform.position,player.position);
        var PlayerIsWithinHugDistance = (distanceFromPersonToPlayer <= attractionDistance);

        if(INeedAHug && PlayerIsWithinHugDistance){
            EventManager.TriggerEvent("OnMonkeyHug",new Dictionary<string, object> {{"PersonStateController", psc}});
        }

    }

    [ExecuteAlways]
    private void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,attractionDistance);
    }
}
