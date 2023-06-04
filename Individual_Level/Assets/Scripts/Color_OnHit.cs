using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_OnHit : MonoBehaviour
{
    //Variables
    public Color col_new = Color.red;

    //if Char Controller has hit something
    private void OnControllerColliderHit (ControllerColliderHit cc_hit)
    {
        //see if it has a tag
        if (cc_hit.gameObject.CompareTag("Colorable"))
        {
            cc_hit.gameObject.GetComponent<Renderer>().material.color = col_new;
        }
    }
}
