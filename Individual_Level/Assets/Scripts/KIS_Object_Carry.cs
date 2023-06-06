using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIS_Object_Carry : MonoBehaviour
{
    // Variables
    public float fl_activation_distance = 3F;
    public Transform tf_pc;

    void Update(){
            //Check for key press
            if (Vector3.Distance(transform.position, tf_pc.position) < fl_activation_distance){
                if (Input.GetKeyDown(KeyCode.F)){
                    PickUp();
                }
            }
    }

    //Pick up function
    void PickUp(){
        Destroy(GetComponent<Rigidbody>());
        Debug.Log("Picked up " + gameObject.name);
        tf_pc.GetComponent<Inventory>().inventoryAdd(gameObject);
        gameObject.SetActive(false);
    }
}