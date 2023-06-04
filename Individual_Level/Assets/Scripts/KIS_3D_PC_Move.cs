// Simple PC 3D Move
// Kennedy Sovine, UoBGames 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIS_3D_PC_Move : MonoBehaviour{

    public float fl_speed = 3;
    public float fl_rotation_rate = 180;
    public float fl_gravity = 10;
    public float fl_jump_force = 5;
    private Vector3 v3_directon = Vector3.zero;
    private CharacterController cc_PC = null;
        
    // Start is called before the first frame update
    void Start(){
        cc_PC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate(){
       //Rotate with mouse
        float _fl_angle =  Input.GetAxis("Mouse X") * fl_rotation_rate * Time.deltaTime;
        transform.Rotate(0, _fl_angle, 0);
     
    

        if (cc_PC.isGrounded){ //If PC is on the ground
            //Get key press and create move vector
            v3_directon = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //convert to local obj coords
            v3_directon = fl_speed * transform.TransformDirection(v3_directon);
            //Check if jump is pressed and apply force
            if (Input.GetButton("Jump")) v3_directon.y = fl_jump_force;
        }
        else{// in air = apply gravity
            v3_directon.y -= fl_gravity * Time.deltaTime;
        }
        //move character
        cc_PC.Move(v3_directon * Time.deltaTime);
    }
}
