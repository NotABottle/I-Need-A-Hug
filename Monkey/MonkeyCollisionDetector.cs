using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyCollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll){
        if(LayerMask.LayerToName(coll.gameObject.layer) == "Ground"){
            EventManager.TriggerEvent("playSound",new Dictionary<string, object>{{"soundName","Contact"}});
        }
    }
}
