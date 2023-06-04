using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIS_Spawner : MonoBehaviour{

    public int in_spawn_total = 100;
    public bool bl_infinite;
    public GameObject go_spawn_object;
    public float fl_coolDown = 0.5f;
    private float fl_next_spawn_time;

    // Update is called once per frame
    void Update(){
        if (bl_infinite && Time.time > fl_next_spawn_time){
            Instantiate(go_spawn_object, transform.position, transform.rotation);
            fl_next_spawn_time = Time.time + fl_coolDown;
        }
        else{
            if (in_spawn_total > 0 && Time.time > fl_next_spawn_time){
                Instantiate (go_spawn_object, transform.position, transform.rotation);
                fl_next_spawn_time = Time.time + fl_coolDown;
                in_spawn_total++;
            }
        }
        
    }
}
