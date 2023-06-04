// ----------------------------------------------------------------------
// -------------------- 3D Trigger Message
// -------------------- David Dorrington, UOB Games, 2022
// ----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Trigger_Send_Message : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public string st_property = "Damage";
    public int in_value = 50;
    public bool bl_time_send;
    public bool bl_destroy_when_used = false;


    // ----------------------------------------------------------------------
    // Detect if something enters the Trigger object
    private void OnTriggerEnter(Collider _cl_collider)
    {
        if (!bl_time_send && _cl_collider.gameObject.tag == "Player")
        {
            _cl_collider.gameObject.SendMessage(st_property, in_value, SendMessageOptions.DontRequireReceiver);

            if (bl_destroy_when_used) Destroy(gameObject);
        }
    }//------

     // ----------------------------------------------------------------------
// Detect in object is within the trigger object
    private void OnTriggerStay(Collider _cl_collider)
    {
        if (bl_time_send && _cl_collider.gameObject.tag == "Player")
        {
            _cl_collider.gameObject.SendMessage(st_property, Time.deltaTime * in_value, SendMessageOptions.DontRequireReceiver);
        }
    }//-----

}//==========
