using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIS_Object_Carry : MonoBehaviour
{
    // Variables
    public float fl_activation_distance = 3F;
    public GameObject ammo;
    public Transform tf_pc;
    private Material mat_object;
    public bool bl_carrying = false;
    private bool bl_has_RB = false;

    //Start
    private void Start(){
        if (tf_pc == null) tf_pc = GameObject.FindWithTag("Player").transform;
        //Check if RigidBody is attatched
        if (GetComponent<Rigidbody>()) bl_has_RB = true;
        tf_pc.GetComponent<KIS_PC_Range_Attack>().enabled = false;
        
    }

    void Update(){
            //Check for key press
            if (Vector3.Distance(transform.position, tf_pc.position) < fl_activation_distance){
            if (Input.GetKeyDown(KeyCode.F)){
                if (!bl_carrying){
                    //stop rigidbody from moving
                    if (bl_has_RB) GetComponent<Rigidbody>().isKinematic = true;

                    //position the obj in front of the PC converting local to world coordinates
                    transform.SetPositionAndRotation(tf_pc.position + tf_pc.TransformDirection(0.3F, 0.3F, 1.3F), tf_pc.rotation);

                    //Child the obejct to the PC
                    transform.parent = tf_pc;
                    bl_carrying = true;
                    GetComponent<Slow_Rotate_Bounce>().enabled = false;
                    ammo.SetActive(false);
                    tf_pc.GetComponent<KIS_PC_Range_Attack>().enabled = true;
                }
        
                else{
                    bl_carrying = false;
                    transform.parent = null;
                    GetComponent<Slow_Rotate_Bounce>().enabled = true;
                    if (bl_has_RB) GetComponent<Rigidbody>().isKinematic = false;
                    tf_pc.GetComponent<KIS_PC_Range_Attack>().enabled = false;
                }
            }
            }
    }
}