using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_PC_Control : MonoBehaviour
{
     //-------------------------------------------------------------------------
    // ----- Movement Variables
    public float fl_speed = 10.0F;
    public float fl_jump_force = 8.0F;
    public float fl_gravity = 20.0F;
    public float fl_rotation_rate = 360;
    private Vector3 v3_move_direction = Vector3.zero;
    private float fl_initial_speed;
    private bool bl_climbing;
    //  Camera
    public GameObject go_PC_camera;
    public float fl_cam_look_speed = 360;
    public float fl_view_angle_limit = 60;
    public float fl_cam_distance = 5;
    // GameObjects
    public GameObject go_weapon;
    private CharacterController cc_PC;


    //-------------------------------------------------------------------------
    // Start is called before the first frame update
    private void Start()
    {
        cc_PC = GetComponent<CharacterController>();
        fl_initial_speed = fl_speed;

        // Hide Cursor - Press Escape to show
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }//-----

    //-------------------------------------------------------------------------
    // Update is called once per frame
    private void Update()
    {
        MovePC();
        MouseLook();
    }//-----


    //-------------------------------------------------------------------------
    private void MouseLook()
    {
        // Zoom in and out with Mouse Scroll
      //  if (Input.mouseScrollDelta.y > 0 && fl_cam_distance > 0.5F) fl_cam_distance -= 0.2F;
     //  if (Input.mouseScrollDelta.y < 0 && fl_cam_distance < 10) fl_cam_distance += 0.2F;


        if (Input.GetAxis("Mouse Y") != 0) // Has the Mouse Y changed?
        {
            float _fl_current_angle = go_PC_camera.transform.rotation.eulerAngles.x;
            float _fl_rotation_angle = 0;

            // Convert to negative number for looking up
            if (_fl_current_angle > 270 && _fl_current_angle < 360) _fl_current_angle = -(360 - _fl_current_angle);

            // Move Cam up 
            if (Input.GetAxis("Mouse Y") > 0)
            {
                _fl_rotation_angle -= fl_cam_look_speed * Time.deltaTime;
                if (_fl_current_angle + _fl_rotation_angle < -fl_view_angle_limit) _fl_rotation_angle = 0;
            }
            // Down
            if (Input.GetAxis("Mouse Y") < 0)
            {
                _fl_rotation_angle += fl_cam_look_speed * Time.deltaTime;
                if (_fl_current_angle + _fl_rotation_angle > fl_view_angle_limit + 5) _fl_rotation_angle = 0;
            }
            // Rotate Camera
            go_PC_camera.transform.Rotate(_fl_rotation_angle, 0, 0);

            // Move the Camera
            go_PC_camera.transform.localPosition = new Vector3(0, go_PC_camera.transform.localPosition.y, -fl_cam_distance);

            // Rotate Gun
            if (go_weapon) go_weapon.transform.rotation = go_PC_camera.transform.rotation;
        }

    }//-----



    //-------------------------------------------------------------------------
    //  PC Movement control
    private void MovePC()
    {
        // If the run key is down double the speed
        if (Input.GetKey(KeyCode.LeftShift))
            fl_speed = fl_initial_speed * 2;
        else
            fl_speed = fl_initial_speed;

        // Rotate PC with Mouse 
        transform.Rotate(0, fl_rotation_rate * Time.deltaTime * Input.GetAxis("Mouse X"), 0);

        //  PC Ground Movement
        if (cc_PC.isGrounded)
        {
            // Add X & Z movement to the direction vector based input axes (W,A,S,D or Cursor) 
            v3_move_direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // Convert world coordinates to local for the PC and multiply by speed
            v3_move_direction = fl_speed * transform.TransformDirection(v3_move_direction);

            // if the jump key is pressed add jump force to the direction vector
            if (Input.GetButton("Jump")) v3_move_direction.y = fl_jump_force;
        }

        // PC Climb Movement
        if (bl_climbing)
        {
            // move slower            
            v3_move_direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            v3_move_direction = fl_speed / 2 * transform.TransformDirection(v3_move_direction);

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


     

}//==========
