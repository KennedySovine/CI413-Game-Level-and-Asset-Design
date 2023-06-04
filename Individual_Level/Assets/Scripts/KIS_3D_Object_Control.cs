// Simple 3D Move
// Kennedy Sovine, UoBGames 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIS_3D_Object_Control : MonoBehaviour
{
    public float fl_speed = 3;
    public float fl_rotation_rate = 180;
 

    // Update is called once per frame
    void Update(){

        transform.Translate(0, 0, Input.GetAxis("Vertical") * fl_speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * fl_rotation_rate * Time.deltaTime, 0);
        
    }
}
