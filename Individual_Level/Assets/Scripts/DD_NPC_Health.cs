// ----------------------------------------------------------------------
// -------------------- NPC / Object Health
// -------------------- David Dorrington, UoB Games, 2023
// ----------------------------------------------------------------------
using UnityEngine;

public class DD_NPC_Health : MonoBehaviour
{  
    // ----------------------------------------------------------------------
    private Vector3 v3_respawn_position;
    public float fl_HP = 100;
    private float fl_max_HP = 100;
    public bool bl_respawn = false;

    // ----------------------------------------------------------------------
    void Start()
    {
        // Set initial respawn position
        v3_respawn_position = transform.position;
    }//-----

    // ----------------------------------------------------------------------
    void Update()
    {
        if (fl_HP <= 0) // health depleted
        {
            if (bl_respawn)
            {
                transform.position = v3_respawn_position;
                fl_HP = fl_max_HP;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }//-----

    // ----------------------------------------------------------------------
    // Damage Receiver
    public void Damage(float fl_damage)
    {   // Subtract the damage sent from current  HP
        fl_HP -= fl_damage;
    }//-----

}//==========
