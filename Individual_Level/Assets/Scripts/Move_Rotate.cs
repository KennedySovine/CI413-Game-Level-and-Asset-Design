using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Rotate : MonoBehaviour
{
    public Vector3 v3_move_speed;
    public Vector3 v3_rotation_rate;

        // Update is called once per frame
    void Update()
    {
        transform.Translate(v3_move_speed * Time.deltaTime * Input.GetAxis("Vertical") );
        transform .Rotate(v3_rotation_rate * Time.deltaTime * Input.GetAxis("Horizontal") );
    }//-----
     
}//==========
