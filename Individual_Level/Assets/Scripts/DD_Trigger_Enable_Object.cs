using System.Collections;
 using System.Collections.Generic;
 using System.Reflection;
 using System.Linq;
 using UnityEngine;
 using System;
 using UnityEngine.UI;

public class DD_Trigger_Enable_Object : MonoBehaviour
{
    // ----------------------------------------------------------------------   
    public GameObject go_key;
    public float fl_activation_distance = 3F;
    public Transform tf_pc;
    private Inventory inventory;
    public GameObject go_message_panel;
    public Text text_panel;


    // ----------------------------------------------------------------------
    void Start()
    {
        // Set the Target object to Disabled if we are to enable it on the trigger 
        if (tf_pc == null) tf_pc = GameObject.FindWithTag("Player").transform;
    }//-----

    // ----------------------------------------------------------------------
    void Update()
    {
        //Check for key press
            if (Vector3.Distance(transform.position, tf_pc.position) < fl_activation_distance){
                if (Input.GetKeyDown(KeyCode.F)){
                    inventory = tf_pc.GetComponent<Inventory>();
                    checkForKey(go_key);
                }
            }
    }//-----  

   void checkForKey(GameObject key){
        if (inventory.inventoryContains(key)){
            inventory.inventoryRemove(key);
            Destroy(gameObject);
        }

        else {
            go_message_panel.SetActive(true);
            text_panel.text = "You dont have the key to open this door.";
            StartCoroutine(ExecuteAfterTime(2));

        }
   }

   IEnumerator ExecuteAfterTime(float time){
         yield return new WaitForSeconds(time);
         go_message_panel.SetActive(false);
   }

}//================