using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KIS_Object_Carry : MonoBehaviour
{
    // Variables
    public float fl_activation_distance = 3F;
    private Transform tf_pc;
    public string[] Note;
    public GameObject go_message_panel;
    public Text txt_window;
    private int in_message_stage;
    public GameObject newWeapon;
    public GameObject oldWeapon;
    
    void Start(){
        tf_pc = GameObject.FindWithTag("Player").transform;
    }
    void Update(){
            //Check for key press
            if (Vector3.Distance(transform.position, tf_pc.position) < fl_activation_distance){
                if (Input.GetKeyDown(KeyCode.F)){
                    if (gameObject.tag == "Note"){
                        noteRead();
                    }
                    else PickUp();
                }
            }
    }

    //Pick up function
    void PickUp(){
        Destroy(GetComponent<Rigidbody>());
        Debug.Log("Picked up " + gameObject.name);
        if (gameObject.tag == "weapon"){
            newWeapon.SetActive(true);
            oldWeapon.SetActive(false);
        }
        tf_pc.GetComponent<Inventory>().inventoryAdd(gameObject);
        gameObject.SetActive(false);
    }

    void noteRead(){
        go_message_panel.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E)){
                if (Note.Length > 1 && (in_message_stage < Note.Length - 1))
                    in_message_stage++;

            // Update the UI text
            txt_window.text = Note[in_message_stage];
        }
        if(in_message_stage == Note.Length - 1){
            go_message_panel.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}