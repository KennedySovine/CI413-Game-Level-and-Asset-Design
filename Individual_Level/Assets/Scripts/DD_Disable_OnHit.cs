using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Disable_OnHit : MonoBehaviour
{   
    // check if the Character Controller has hit Something
    private void OnControllerColliderHit(ControllerColliderHit cc_hit)
    {
        //Check if what we are hitting has a tag
        if (cc_hit.gameObject.CompareTag("Enemy"))
        {
            cc_hit.gameObject.SetActive(false);
        }
    }//-----

}//==========

