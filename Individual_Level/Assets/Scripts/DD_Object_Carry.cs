// ------------------------------------------------------------
//  ----------  Object Carry
//  ---------- David Dorrington, UoBGames 23 
// ------------------------------------------------------------

using UnityEngine;

public class DD_Object_Carry : MonoBehaviour
{
    // ------------------------------------------------------------
    public Color col_highlight = Color.yellow;
    private Color col_original;
    public float fl_activation_distance = 2F;
    public Transform tf_pc;
    private Material mat_object;
    private bool bl_carrying = false;
    private bool bl_has_RB = false;

    // ------------------------------------------------------------
    private void Start()
    {
        if (tf_pc == null) tf_pc = GameObject.FindWithTag("Player").transform;
        mat_object = GetComponent<Renderer>().material;
        col_original = mat_object.color;       
        // Check if Rigidbody attached
        if (GetComponent<Rigidbody>()) bl_has_RB = true;
    }//----


    // ------------------------------------------------------------
    void Update()
    {   // are we in activation distance
        if (Vector3.Distance(transform.position, tf_pc.position) < fl_activation_distance) 
        {
            if (!bl_carrying) // Highlight the object is interactable 
            {
                if (mat_object.color == col_original) mat_object.color = col_highlight;
            }
            else
            {
                mat_object.color = col_original;
            }

            // Check For Key Press
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!bl_carrying)
                {   // if there is a Rigid body stop it moving                                 
                    if(bl_has_RB) GetComponent<Rigidbody>().isKinematic= true;

                    // position the object in front of the PC converting local to world coordinates
                    transform.SetPositionAndRotation(tf_pc.position + tf_pc.TransformDirection(0.3F, 0.3F, 1.3F), tf_pc.rotation);

                   // Child this object to the PC
                    transform.parent = tf_pc;
                    bl_carrying = true;
                }
                else
                {
                    bl_carrying = false;
                    transform.parent = null;
                    if (bl_has_RB) GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }
        else if (Vector3.Distance(transform.position, tf_pc.position) < fl_activation_distance + 1)
        {  // Reset the colour as we move away
            mat_object.color = col_original;
        }

    }//-----
        
}//==========
