// ----------------------------------------------------------------------
// -------------------- 3D Rotate
// -------------------- David Dorrington, UoB, 2022
// ----------------------------------------------------------------------
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Rotate : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public Vector3 v3_rotation_rate = new Vector3(0,90,0);

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(v3_rotation_rate * Time.deltaTime);

    }//-----

}//==========
