// ------------------------------------------------------------
//  ----------  Rigidbody Push
//  ---------- David Dorrington, UoBGames 23 
// ------------------------------------------------------------

using UnityEngine;

public class DD_RB_Push : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public float fl_force = 10;
    private bool bl_touching_RB;
    private Rigidbody rb_target;

    // ----------------------------------------------------------------------
    // This update is used for physics objects
    void FixedUpdate()
    {
        if (bl_touching_RB)
        {
            // Convert the local Character direction to world coords
            Vector3 _V3_direction = transform.TransformDirection(Vector3.forward);

            // Apply the force to the object if there is a Rigidbody
            if (rb_target)
            {
                rb_target.AddForce(fl_force * new Vector3(_V3_direction.x, 0, _V3_direction.z));
            }

            bl_touching_RB = false;
        }
    }//-----


    // ----------------------------------------------------------------------
    // Char Controller has Hit something 
    void OnControllerColliderHit(ControllerColliderHit cc_hit)
    {
        // Has the PC bumped into an object it can push 
        if (cc_hit.collider.attachedRigidbody && cc_hit.moveDirection.y > -0.2F)
        {
            // Set the target
            rb_target = cc_hit.collider.attachedRigidbody;
            bl_touching_RB = true;
        }
    }//------
}//==========
