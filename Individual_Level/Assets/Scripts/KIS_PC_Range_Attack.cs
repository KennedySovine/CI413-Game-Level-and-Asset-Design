using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIS_PC_Range_Attack : MonoBehaviour
{

    //Combat Variables
    public GameObject go_projectile;
    public float fl_cooldown = 1;
    private float fl_next_shot_time;

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack(){
        //Fire1 is CTRL and left mouse button
        if (Input.GetButton("Fire1") && Time.time > fl_next_shot_time){
            //Reset the cooldown delay
            fl_next_shot_time = Time.time + fl_cooldown;

            //Create projectile in fornt of the pC
            Instantiate (go_projectile, transform.position + transform.TransformDirection(new Vector3(0.5f, 0.5f, 1.5f)), transform.rotation);
        }
    }
}
