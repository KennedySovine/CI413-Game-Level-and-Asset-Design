using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KIS_Projectile : MonoBehaviour
{

    //Variables
    public float fl_range = 20;
    public float fl_speed = 10;
    public float fl_damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, fl_range / fl_speed);
        GetComponent<Rigidbody>().velocity = fl_speed * transform.TransformDirection (Vector3.forward);
    }

   void OnCollisionEnter(Collision _object_hit){
       _object_hit.collider.gameObject.SendMessage("Damage", fl_damage, SendMessageOptions.DontRequireReceiver);
       Destroy(gameObject);
   }
}
