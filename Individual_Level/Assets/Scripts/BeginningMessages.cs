using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginningMessages : MonoBehaviour
{
    public GameObject go_message_panel;
    public GameObject canvas;
    public Text text_panel;
    private int count = 0;
    private GameObject PC;
    /*float timer;
    public float delay = 5;*/
    private string[] messages = {"You don't know why you're here, do you?", "The world has lost its color.", "No one can see the beauty of the world anymore.", "You must help them!"};
    void Start(){
        Screen.lockCursor = true;
        //Disable Player Control when in cutscene
        PC =GameObject.FindWithTag("Player");
        PC.GetComponent<DD_PC_Control>().enabled = false;
    }
    void Update(){ 

        if (Input.GetKeyDown("space")){
            //Debug.Log(count);
            if (count  == 4){
                //Debug.Log("Check");
                go_message_panel.SetActive(false);
                PC.GetComponent<DD_PC_Control>().enabled = true;
            }
            else{
                text_panel.text = messages[count];
                count++;
            }
        }
    }
}
