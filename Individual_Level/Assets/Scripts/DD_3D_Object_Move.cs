// ------------------------------------------------------------
//  ---------- Simple 3D Move
//  ---------- David Dorrington, UoBGames 23 
// ------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_3D_Object_Move : MonoBehaviour
{
    // ------------------------------------------------------------
    public Vector3 v3_rotation = new Vector3(0, 90, 0);
    public Vector3 v3_velocity = new Vector3(0, 0, 1);
     

    // ------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(v3_rotation * Time.deltaTime);
        transform.Translate(v3_velocity * Time.deltaTime);

    }//-----

}//=========
