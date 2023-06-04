// ----------------------------------------------------------------------
// -------------------- 3D PC Raycast Range Attack
// -------------------- David Dorrington, UEL Games, 2018
// ----------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DD_Raycast_Attack : MonoBehaviour
{
    // ----------------------------------------------------------------------
    // Range Weapon Variables
    public float fl_damage = 10;
    public float fl_cooldown = 0.1F;
    public float fl_accuracy = 100;
    private float fl_range = 50;
    public float fl_hit_force = 100;  
    private float fl_next_attack_time;
    public Transform tx_weapon;
    private LineRenderer line_laser;
    private Camera go_PC_camera;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        line_laser = GetComponent<LineRenderer>();
        tx_weapon = transform.Find("Gun").transform;
        go_PC_camera = GetComponentInChildren<Camera>();
    }//----

    // Update is called once per frame
    void Update()
    {
        RayAttack();
    } //-----

    // ----------------------------------------------------------------------
    void RayAttack()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > fl_next_attack_time)
        {   //Reset next shot time
            fl_next_attack_time = Time.time + fl_cooldown;
            
            StartCoroutine(ShotEffect());

            // Temp Variables
            Vector3 _v3_ray_origin = go_PC_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit _hit;

            // set the line renderer start to the weapon
            line_laser.SetPosition(0, tx_weapon.position);

            // cast a ray and has it hit something
            if (Physics.Raycast(_v3_ray_origin, go_PC_camera.transform.forward, out _hit, fl_range))
            {
                // Set the line renderer end position the objectr hit
                line_laser.SetPosition(1, _hit.point);           

                //send damage to what we hit by accessing the health script
                if (_hit.collider.gameObject.GetComponent<DD_NPC_Health>())
                    _hit.collider.gameObject.GetComponent<DD_NPC_Health>().Damage(fl_damage);

                // Send force to what we hit it has a rigid body
                if (_hit.rigidbody)
                    _hit.rigidbody.AddForce(-_hit.normal * fl_hit_force);
            }
            else
            {   // set the end of the line renderer and the range
                line_laser.SetPosition(1, _v3_ray_origin + (go_PC_camera.transform.forward) * fl_range);
            }
        }
    }//-----

    // ----------------------------------------------
    // Coroutine for displaying for laser line
    private IEnumerator ShotEffect()
    {   //add sound fx here 

        line_laser.enabled = true;
        yield return new WaitForSeconds(0.07F);
        line_laser.enabled = false;
    }//----
}//==========