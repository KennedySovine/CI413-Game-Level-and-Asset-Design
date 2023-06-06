using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIS_NPC_Health : MonoBehaviour
{
    //Variables
    private Vector3 v3_respawn_position;
    public float fl_HP = 100;
    private float fl_max_HP = 100;
    public bool bl_respawn = false;

    // Start is called before the first frame update
    void Start()
    {
        //Set initial respawn position
        v3_respawn_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (fl_HP <= 0){ //Health is depleted
            if (bl_respawn){
                transform.position = v3_respawn_position;
                fl_HP = fl_max_HP;
            }
            else {
                Destroy(gameObject);
            }
        }
    }
    //Damage Reciever
    public void Damage (float fl_damage){
        Debug.Log("Damage Recieved");
        fl_HP -= fl_damage;
    }

    //Collider that detects projectiles
    void OnTriggerEnter(Collider collision){
        Debug.Log("Collision Detected");
        if (collision.gameObject.tag == "Projectile"){
            Damage(collision.GetComponent< KIS_Projectile>().fl_damage);
        }
    }
}