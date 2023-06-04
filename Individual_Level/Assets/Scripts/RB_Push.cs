using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_Push : MonoBehaviour
{
    //Variables
    public float fl_force = 10;
    private bool bl_touching_RB;
    private Rigidbody rb_target;

    // Update is used for physics objects
    void FixedUpdate()
    {
        if (bl_touching_RB){
            //Convert the local Character direction to world coords
            Vector3 _V3_direction = transform.TransformDirection(Vector3.forward);

            //Apply the force of the object if theres a rigidbody
            if (rb_target){
                rb_target.AddForce(fl_force * new Vector3(_V3_direction.x, 0, _V3_direction.z));
            }
            bl_touching_RB = false;
        }
    }

    //Char Controller hit something
    void OnControllerColliderHit(ControllerColliderHit cc_hit){
        //has PC bumped into an obj it can push#
        if (cc_hit.collider.attachedRigidbody && cc_hit.moveDirection.y > -0.2F){
            //Set target
            rb_target = cc_hit.collider.attachedRigidbody;
            bl_touching_RB = true;
        }
    }
}
