using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIS_CheckPoint : MonoBehaviour
{

    public bool bl_destroy_when_hit = true;

    //Detect if something enters the trigger
    void OnTriggerStay (Collider collider_touching){
        //Update PC respawn position
        collider_touching.GetComponent<KIS_PC_Health>().v3_respawn_position = transform.position;

        if (bl_destroy_when_hit){
            Destroy(gameObject);
        }
    }
}
