// ----------------------------------------------------------------------
// -------------------- 3D PC Multiple weapon system
// -------------------- David Dorrington, 2023
// ----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DD_Ranged_Weapons : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public static List<Weapon> weapons;
    public static List<Ammo> munitions;
    public static int in_current_weapon = 0;
    private float fl_next_attack_time;

    public GameObject go_hit_marker;

    public Transform tx_weapon;
    private LineRenderer line_laser;
    private Camera go_PC_camera;


    public Text text_Arms_HUD;
    public Text text_Ammunition_HUD;

    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        line_laser = GetComponent<LineRenderer>();
        if (!tx_weapon) tx_weapon = transform.Find("Weapon").transform;
        go_PC_camera = GetComponentInChildren<Camera>();

        weapons = new List<Weapon>
        {
        new Weapon() {Name = "Pistol",        Carrying = true, Ammo_type = 0, Clip_size = 10,  Range = 30,   Damage = 10, Cool_down = 0.5F, Hit_force = 100},
        new Weapon() {Name = "Rifle",         Carrying = true, Ammo_type = 0, Clip_size = 30,  Range = 50,   Damage = 30, Cool_down = 1f , Hit_force = 300} ,
        new Weapon() {Name = "Shotgun",       Carrying = true, Ammo_type = 2, Clip_size = 50,  Range = 15,   Damage = 10, Cool_down =   1f , Hit_force = 50},
        new Weapon() {Name = "Sniper_Rifle",  Carrying = true, Ammo_type = 1, Clip_size = 6,   Range = 100,  Damage = 100, Cool_down = 4 , Hit_force = 500},
        new Weapon() {Name = "LMG",           Carrying = true, Ammo_type = 0, Clip_size = 50,  Range = 50,   Damage = 30, Cool_down = 0.2f , Hit_force = 100} 
        };

        munitions = new List<Ammo> 
        {
            new Ammo() { Name = "Bullets", Amount = 50, Max_amount = 200 },
            new Ammo() { Name = "Rounds", Amount = 5, Max_amount = 10},
            new Ammo() { Name = "Shells", Amount = 25, Max_amount = 50},
        };

    }//-----


    // ----------------------------------------------------------------------
    private void Update()
    {
        SwitchWeapon();
        DisplayMunitions();
        FireWeapon();
    }//-----


    // Ammo Pickup receivers
    public void Bullet(int _in_amount)
    {

        munitions[0].Amount += _in_amount;
        if (munitions[0].Amount > munitions[0].Max_amount)
            munitions[0].Amount = munitions[0].Max_amount;
    }//-----

    // Ammo Pickup receivers
    public void Round(int _in_amount)
    {
        munitions[1].Amount += _in_amount;
        if (munitions[1].Amount > munitions[1].Max_amount)
            munitions[1].Amount = munitions[1].Max_amount;
    }//----

    // Ammo Pickup receivers
    public void Shell(int _in_amount)
    {
        munitions[2].Amount += _in_amount;
        if (munitions[2].Amount > munitions[2].Max_amount)
            munitions[2].Amount = munitions[2].Max_amount;
    }//----



    // ----------------------------------------------------------------------
    private void FireWeapon()
    {
        if (Input.GetButton("Fire1") && munitions[weapons[in_current_weapon].Ammo_type].Amount > 0 && Time.time > fl_next_attack_time)
        {
            if (in_current_weapon == 2) // shotgun
            {
                for (int _index = 1; _index < 12; _index++)
                {
                    FireWeapon(3);
                }
            }
            else
            {
                FireWeapon(0);
            }

            //Reset next shot time
            fl_next_attack_time = Time.time + weapons[in_current_weapon].Cool_down;

            // Reduce Ammo
            munitions[weapons[in_current_weapon].Ammo_type].Amount--;
        }
    }//-----


    // ----------------------------------------------------------------------


    private void FireWeapon(float _fl_accuracy)
    {
        StartCoroutine(ShotEffect());

        // Temp Variables
        Vector3 _v3_ray_origin = go_PC_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        // set the line renderer start to the weapon
        line_laser.SetPosition(0, tx_weapon.position);

        Vector3 _v3_accuracy_offset = new Vector3(Random.Range(-_fl_accuracy, _fl_accuracy) / 50, Random.Range(-_fl_accuracy, _fl_accuracy) / 50, 0);

        Vector3 _v3_direction = go_PC_camera.transform.forward + go_PC_camera.transform.TransformDirection(_v3_accuracy_offset);


        // cast a ray and has it hit something
        if (Physics.Raycast(_v3_ray_origin, _v3_direction, out RaycastHit _hit, weapons[in_current_weapon].Range))
        {
            // Set the line renderer end position the objectr hit
            line_laser.SetPosition(1, _hit.point);

            Instantiate(go_hit_marker, _hit.point, Quaternion.identity);

            // Send Damage to what is hit
            _hit.collider.SendMessage("Damage", weapons[in_current_weapon].Damage, SendMessageOptions.DontRequireReceiver);

            // Send force to what we hit it has a rigid body
            if (_hit.rigidbody)
                _hit.rigidbody.AddForce(-_hit.normal * weapons[in_current_weapon].Hit_force);
        }
        else
        {   // set the end of the line renderer and the range

            Vector3 _v3_end_point = _v3_ray_origin + (go_PC_camera.transform.forward) * weapons[in_current_weapon].Range;

            line_laser.SetPosition(1, _v3_end_point);
        }
    }//  -----  

    // ----------------------------------------------
    // Coroutine for displaying for laser line
    private IEnumerator ShotEffect()
    {
        //add sound fx here   
        GetComponent<AudioSource>().Play();

        // Show lases beam
        line_laser.enabled = true;
        yield return new WaitForSeconds(0.01F);
        line_laser.enabled = false;
    }//----


    // ----------------------------------------------------------------------
    private void SwitchWeapon()
    {
        if (Input.mouseScrollDelta.y < 0) // Rolled Down
        {
            fl_next_attack_time = Time.time;

            in_current_weapon++;
            if (in_current_weapon > weapons.Count - 1) in_current_weapon = 0;
        }
        if (Input.mouseScrollDelta.y > 0) // Rolled Up
        {
            fl_next_attack_time = Time.time;

            in_current_weapon--;
            if (in_current_weapon < 0) in_current_weapon = weapons.Count - 1;
        }


    }//-----


    // ----------------------------------------------
    private void DisplayMunitions()
    {
        text_Arms_HUD.text = weapons[in_current_weapon].Name;
        text_Ammunition_HUD.text = "Ammo:\n";
        for (int _index = 0; _index < munitions.Count; _index++)
        {
            text_Ammunition_HUD.text += munitions[_index].Name + "  " + munitions[_index].Amount + " / " + munitions[_index].Max_amount + "\n";
        }
    }//------


    // ----------------------------------------------------------------------
    // Define the ammo variables for the inventory
    public class Ammo
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Max_amount { get; set; }
    }//----

    // ----------------------------------------------------------------------
    // Define the weapon objects variables for the inventory
    public class Weapon
    {
        public string Name { get; set; }
        public bool Carrying { get; set; }
        public int Ammo_type { get; set; }
        public int Clip_size { get; set; }
        public int Range { get; set; }
        public int Damage { get; set; }
        public float Cool_down { get; set; }
        public float Hit_force { get; set; }
    }//-----

}//==========
