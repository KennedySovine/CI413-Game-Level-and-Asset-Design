// ----------------------------------------------------------------------
// -------------------- 3D
// -------------------- David Dorrington,22
// ----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Trigger_Damage : MonoBehaviour
{
   
    //-------------------------------------------------------------------------
    public float fl_damage_rate = 100;


    //-------------------------------------------------------------------------
    void OnTriggerStay(Collider cl_detected)
    {
        cl_detected.SendMessage("Damage", fl_damage_rate * Time.deltaTime, SendMessageOptions.DontRequireReceiver);

    }//-----
}
