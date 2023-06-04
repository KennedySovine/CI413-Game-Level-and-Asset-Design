// ----------------------------------------------------------------------
// -------------------- PC Simple Health
// -------------------- David Dorrington, UoB Games, 2023
// ---------------------------------------------------------------------
using UnityEngine;

public class DD_PC_Health : MonoBehaviour
{
    // ----------------------------------------------------------------------
    public Vector3 v3_respawn_position;
    public float fl_HP = 100;
    public float fl_max_HP = 100;
    public float fl_max_safe_fall_height = 5;
    public float fl_fall_damage = 20;
    public float fl_fatal_fall_height = 15;
    private float fl_fall_start_height;

    public Transform tf_HP_bar;
    private CharacterController cc_PC;
    public GameObject go_hit_text;


    // ----------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        if (!tf_HP_bar) tf_HP_bar = transform.Find("HP_Bar").GetComponent<Transform>();

        cc_PC = GetComponent<CharacterController>();
        v3_respawn_position = transform.position;

    }//-----

    // ----------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        CheckFalling();
        CheckHealth();
        ResizeBar();
    }//-----

    // ----------------------------------------------------------------------
    void CheckFalling()
    {
        if (!cc_PC.isGrounded) // in the air
        {  // set the maximum height the PC has reached in the air 
            if (transform.position.y > fl_fall_start_height) fl_fall_start_height = transform.position.y;
        }
        else // on the ground
        {
            // is the fall height damaging
            if (fl_fall_start_height - transform.position.y > fl_max_safe_fall_height)
                fl_HP -= fl_fall_damage; // subtract damage from HP

            if (fl_fall_start_height - transform.position.y > fl_fatal_fall_height)
                fl_HP = -1; // Kill the PC

            // reset the fall height
            fl_fall_start_height = transform.position.y;
        }
    }//-----




    // ----------------------------------------------------------------------
    // Resize the HP Bar
    void ResizeBar()
    {   // is there an HP bar attached
        if (tf_HP_bar)
        {   // Resize and colour the bar based on current HP
            tf_HP_bar.localScale = new Vector3((fl_HP / fl_max_HP), 0.1F, 0.1F);
            if (fl_HP > fl_max_HP / 2) tf_HP_bar.GetComponent<Renderer>().material.color = Color.green;
            if (fl_HP > fl_max_HP / 4 && fl_HP < fl_max_HP / 2) tf_HP_bar.GetComponent<Renderer>().material.color = Color.yellow;
            if (fl_HP < fl_max_HP / 4) tf_HP_bar.GetComponent<Renderer>().material.color = Color.red;
        }
    }//-----

    // ----------------------------------------------------------------------
    // 
    void CheckHealth()
    {
        if (fl_HP <= 0) // health depleted
        {
            transform.position = v3_respawn_position;
            fl_HP = fl_max_HP;
        }
    }//------

    // ----------------------------------------------------------------------
    // Damage Receiver
    public void Damage(float _fl_damage)
    {
        // Subtract the damage sent from HP
        fl_HP -= _fl_damage;

        // Create text mesh to show hit damage
        GameObject _go_hit_text = Instantiate(go_hit_text, transform.position + Vector3.up, transform.rotation) as GameObject;
        _go_hit_text.GetComponent<TextMesh>().text = _fl_damage.ToString();
        _go_hit_text.GetComponent<TextMesh>().color = Color.red;


    }//-----

    // ----------------------------------------------------------------------
    // Health Receiver
    public void Health(float _fl_health)
    {
        // Add the health pichup to HP
        fl_HP += _fl_health;

        // Create text mesh to show health
        GameObject _go_hit_text = Instantiate(go_hit_text, transform.position + Vector3.up, transform.rotation) as GameObject;
        _go_hit_text.GetComponent<TextMesh>().text = _fl_health.ToString();
        _go_hit_text.GetComponent<TextMesh>().color = Color.green;


    }//-----

}//==========
