// ----------------------------------------------------------------------
// -------------------- 3D 
// -------------------- David Dorrington, UOB Games, 2023
// ----------------------------------------------------------------------
using UnityEngine;

public class DD_PickUp_Trigger : MonoBehaviour {

    // ----------------------------------------------------------------------
    public string st_property = "Health";
    public int in_value = 10;

    // ----------------------------------------------------------------------
    // Detect if something enters the Trigger
    void OnTriggerEnter(Collider _cl_collider)
    {
        if (_cl_collider.gameObject.tag == "Player")
        {
            _cl_collider.gameObject.SendMessage(st_property, in_value, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }//------

}//==========