// ----------------------------------------------------------------------
// --------------------  Simple NPC
// -------------------- David Dorrington, UoB Games, 2023
// ---------------------------------------------------------------------
using UnityEngine;

public class DD_NPC_Chase : MonoBehaviour
{
    // Combat Variables
    public GameObject go_projectile;
    public float fl_attack_range = 20;
    public float fl_cooldown = 1;
    private float fl_next_shot_time;
    public Transform tf_target;

    // Movement Variables
    public bool bl_chase_target = false;
    public float fl_chase_dist_max = 10;
    public float fl_chase_dist_min = 3;
    public float fl_chase_speed = 5;
    private CharacterController cc_NPC;

    // ----------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        if (!tf_target) tf_target = GameObject.FindGameObjectWithTag("Player").transform;
        cc_NPC = GetComponent<CharacterController>();
    }//-----

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if (tf_target)
        {
            if (bl_chase_target) NPC_Move();
            AttackTarget();
        }
    }//----

    private void NPC_Move()
    {     
       // Is the target in Range
        if (Vector3.Distance(transform.position, tf_target.position) < fl_chase_dist_max)
        {   // Face the Target
            transform.LookAt(tf_target.position);

            if (Vector3.Distance(transform.position, tf_target.position) > fl_chase_dist_min)
            {   // Move towards the target
                cc_NPC.SimpleMove(fl_chase_speed * transform.TransformDirection(Vector3.forward));
            }
        }
    }//-----


    private void AttackTarget()
    {
        if (fl_next_shot_time < Time.time && Vector3.Distance(this.transform.position, tf_target.position) < fl_attack_range)
        {
            transform.LookAt(tf_target);
            // Spawn a Projectile
            Instantiate(go_projectile, transform.position + transform.TransformDirection(new Vector3(0, 0, 1F)), transform.rotation);

            //Reset Cooldown
            fl_next_shot_time = Time.time + fl_cooldown;
        }
    }//-----

}//===========
