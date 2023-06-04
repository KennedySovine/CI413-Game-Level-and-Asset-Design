// ------------------------------------------------------------
//  ---------- Simple PC 3D Move
//  ---------- David Dorrington, UoBGames 23 
// ------------------------------------------------------------
using UnityEngine;

public class DD_PC_Move : MonoBehaviour
{
    //-------------------------------------------------------------------------
    // ----- Movement Variables
    public float fl_speed = 10.0F;
    public float fl_jump_force = 8.0F;
    public float fl_gravity = 20.0F;
    public float fl_rotation_rate = 180F;
    public float fl_run_muliplier = 2F;
    private Vector3 v3_move_direction = Vector3.zero;  
 
    private bool bl_climbing = false;
    private bool bl_running = false;

    // Add the run speed
    float fl_speed_multiplier = 1;

    // GameObjects  
    private CharacterController cc_PC;


    //-------------------------------------------------------------------------
    // Start is called before the first frame update
    private void Start()
    {
        cc_PC = GetComponent<CharacterController>();    

        // Hide Cursor - Press Escape to show
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }//-----

    //-------------------------------------------------------------------------
    // Update is called once per frame
    private void Update()
    {
        MovePC();
    }//-----



    //-------------------------------------------------------------------------
    //  PC Movement control
    private void MovePC()
    {
        // Toggle Run State
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (bl_running)
                bl_running = false;
            else
                bl_running = true;
        }

        // Rotate PC with Mouse 
        transform.Rotate(0, fl_rotation_rate * Time.deltaTime * Input.GetAxis("Mouse X"), 0);

        //  PC Ground Movement
        if (cc_PC.isGrounded)
        {
            // Add X & Z movement to the direction vector based input axes (W,A,S,D or Cursor) 
            v3_move_direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // Change Speed if Running
            if (bl_running)
                fl_speed_multiplier = fl_run_muliplier;
            else
                fl_speed_multiplier = 1;

            // Convert world coordinates to local for the PC and multiply by speed
            v3_move_direction = fl_speed * fl_speed_multiplier * transform.TransformDirection(v3_move_direction);

            // if the jump key is pressed add jump force to the direction vector
            if (Input.GetButton("Jump")) v3_move_direction.y = fl_jump_force;
        }

        // PC Climb Movement
        if (bl_climbing)
        {
            // move          
            v3_move_direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            v3_move_direction = fl_speed * transform.TransformDirection(v3_move_direction);

            // Climb
            if (Input.GetButton("Jump")) v3_move_direction.y = fl_speed;
        }
        else
        {   // Add fl_gravity to the direction vector
            v3_move_direction.y -= fl_gravity * Time.deltaTime;
        }

        // Move the character controller with the direction vector
        cc_PC.Move(v3_move_direction * Time.deltaTime);
    }// -----


    //-------------------------------------------------------------------------
    // When PC enters a trigger
    void OnTriggerStay(Collider _cl_trigger_collider)
    {
        if (_cl_trigger_collider.gameObject.CompareTag("Moving")) transform.SetParent(_cl_trigger_collider.transform, true);
        if (_cl_trigger_collider.gameObject.CompareTag("ClimbZone")) bl_climbing = true;
    }//-----


    //-------------------------------------------------------------------------
    // PC Leaving the Trigger
    void OnTriggerExit(Collider cl_trigger_collider)
    {
        if (cl_trigger_collider.gameObject.CompareTag("Moving")) transform.parent = null;
        if (cl_trigger_collider.gameObject.CompareTag("ClimbZone")) bl_climbing = false;
    }//-----    

}//==========
