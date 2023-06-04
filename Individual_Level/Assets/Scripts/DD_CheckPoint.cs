// ------------------------------------------------------------
//  ----------  CheckPoint 
//  ---------- David Dorrington, UoBGames 23 
// ------------------------------------------------------------
using UnityEngine;

public class DD_CheckPoint : MonoBehaviour
{
    public bool bl_destoy_when_hit = true;

    // ----------------------------------------------------------------------
    // Detect if something enters the Trigger
    void OnTriggerStay(Collider collider_touching)
    {
        if (collider_touching.gameObject.CompareTag("Player"))
        {   // update the PC respawn postition
            collider_touching.GetComponent<DD_PC_Health>().v3_respawn_position = transform.position;

            if (bl_destoy_when_hit) Destroy(gameObject);
        }
    }//-----
}//==========