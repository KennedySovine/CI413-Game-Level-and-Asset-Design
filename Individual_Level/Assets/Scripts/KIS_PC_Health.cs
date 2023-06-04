using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIS_PC_Health : MonoBehaviour
{
    //Variables
    public Vector3 v3_respawn_position;
    public float fl_HP = 100;
    public float fl_max_HP = 100;

    void Start(){
        v3_respawn_position = transform.position;
    }

    void Update(){
        if (fl_HP <= 0){ //Health is depleted
            //Respawn - Auto sync Transform for this to work
            transform.position = v3_respawn_position;
            fl_HP = fl_max_HP;
        }
    }

    //Damage Reciever
    public void Damage(float fl_damage){
        //Subtract the damage from HP
        fl_HP -= fl_damage;
    }
}
