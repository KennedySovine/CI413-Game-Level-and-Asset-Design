// ----------------------------------------------------------------------
// -------------------- 3D NPC Patrol
// -------------------- David Dorrington,22
// ----------------------------------------------------------------------

using UnityEngine;

public class DD_NPC_Patrol : MonoBehaviour
{
    // ----------------------------------------------------------------------
    // Combat Variables
    public GameObject go_projectile;
    public float fl_range = 15;
    public float fl_cool_down = 1;
    public int in_ammo = 10000;
    public float fl_accuracy = 100;
    private float fl_delay;
    public bool bl_line_of_sight;
    public string st_target_class = "Player";

    // Movement
    public Transform[] tf_waypoints;
    public float fl_speed = 3;
    private int in_next_wp = 0;

    public Transform tf_target;
    private CharacterController cc_attached;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {   // Find the Game Objects we need to interact with
        cc_attached = GetComponent<CharacterController>();
        // if no target is set find the first tagged as the enemy
        if (!tf_target)
            tf_target = GameObject.FindWithTag(st_target_class).transform;
    }//-----

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        // The 2 states of this NPC
        if (Vector3.Distance(transform.position, tf_target.transform.position) < fl_range)
            AttackTarget(); // Atack if in range
        else
            Patrol();

    }//-----

    // ----------------------------------------------------------------------
    void Patrol()
    {
        //Are there any waypoints defined?
        if (tf_waypoints.Length > 0)
        {   // Look at the next WP
            transform.LookAt(tf_waypoints[in_next_wp].position);

            // Move towards the WP
            cc_attached.SimpleMove(fl_speed * transform.TransformDirection(Vector3.forward));

            // if we get close, increment the target in the List
            if (Vector3.Distance(tf_waypoints[in_next_wp].position, transform.position) < 1)
            {
                if (in_next_wp < tf_waypoints.Length - 1)
                    in_next_wp++;
                else
                    in_next_wp = 0;
            }
        }
    }//-----


    // ----------------------------------------------------------------------
    void AttackTarget()
    {
        // Does the NPC have ammo and has the cooldown passed
        if (in_ammo > 0 && Time.time > fl_delay)
        {
            // Face the Target
            transform.LookAt(tf_target.position);
            cc_attached.SimpleMove(Vector3.zero); // stop moving

            // Is the line of sight flag checked? 
            if (bl_line_of_sight)
            {
                // Cast a Ray to check if Target in is view of NPC
                RaycastHit rc_hit;
                Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rc_hit, fl_range);

                // if the Target is in sight create a projectile
                if (rc_hit.collider != null && rc_hit.collider.gameObject == tf_target) FireProjectile();

            }
            else
            {   // Shoot at Target even if there is something in the way            
                FireProjectile();
            }
        }
    }//------

    // ----------------------------------------------------------------------
    void FireProjectile()
    {
        // Spawn an arrow     
        GameObject _go_projectile_clone = Instantiate(go_projectile, transform.position + transform.TransformDirection(new Vector3(0, 0, 1F)), transform.rotation);

        // Create a random rotation based on accuracy
        Vector3 _V3_accuracy_offset = new Vector3(Random.Range(-100 + fl_accuracy, 100 - fl_accuracy) / 10, Random.Range(-100 + fl_accuracy, 100 - fl_accuracy) / 10, 0);

        _go_projectile_clone.transform.Rotate(_V3_accuracy_offset);

        fl_delay = Time.time + fl_cool_down;
        in_ammo--;
    }//-----

}//==========
