// ----------------------------------------------------------------------
// -------------------- Simple Range Attack
// -------------------- David Dorrington, UoB Games, 2023
// ----------------------------------------------------------------------

using UnityEngine;

public class DD_PC_Range_Attack : MonoBehaviour
{
    // Combat Variables
    public GameObject go_projectile;
    public float fl_cooldown = 1;
    public Vector3 v3_fire_Position = new Vector3(1, 1, 1.5F);
    private float fl_next_shot_time;
    public Transform tf_PC_camera;


    private void Start()
    {
        if (!tf_PC_camera) tf_PC_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // ----------------------------------------------------------------------     
    void Update()
    {
        Attack();
    }//-----   

    // ----------------------------------------------------------------------
    void Attack()
    {
        // "Fire1" is CTRL and Left Mouse Button
        if (Input.GetButton("Fire1") && Time.time > fl_next_shot_time)
        {
            // Reset the cooldown delay
            fl_next_shot_time = Time.time + fl_cooldown;

            // Create Projectile in front  of PC
            Instantiate(go_projectile, transform.position
                + transform.TransformDirection(v3_fire_Position), tf_PC_camera.rotation);
        }
    }//-----

}//==========