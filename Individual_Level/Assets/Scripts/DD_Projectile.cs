// ----------------------------------------------------------------------
// -------------------- 3D Projectile
// -------------------- David Dorrington, UoB Games, 2023
// ----------------------------------------------------------------------
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DD_Projectile : MonoBehaviour
{
    // Variables
    public float fl_range = 20;
    public float fl_speed = 10;
    public float fl_damage = 10;

    // ----------------------------------------------------------------------
    void Start()
    {
        Destroy(gameObject, fl_range / fl_speed);
        GetComponent<Rigidbody>().velocity = fl_speed * transform.TransformDirection(Vector3.forward);
    } //-----	

    // ----------------------------------------------------------------------
    void OnCollisionEnter(Collision _object_hit)
    {
        _object_hit.collider.gameObject.SendMessage("Damage", fl_damage, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }//-----


}//=========
