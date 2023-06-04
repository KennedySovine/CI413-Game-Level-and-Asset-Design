// ----------------------------------------------------------------------
// -------------------- Simple Message by distance
// -------------------- David Dorrington, UoB Games, 22
// ----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is added

public class DD_Message : MonoBehaviour
{
    public float fl_activation_distance = 2;
    public string st_message = "Replace this text with a Gameplay Message";
    public GameObject go_message_panel;
    public Text text_panel;
    private GameObject go_PC;

    // ----------------------------------------------------------------------
    void Start()
    {
        go_PC = GameObject.FindWithTag("Player");   
    } //-----

    // ----------------------------------------------------------------------
       void Update()
    {
        // Is the PC in range?
        if (Vector3.Distance(go_PC.transform.position, transform.position) < fl_activation_distance)
        {
            go_message_panel.SetActive(true);
            text_panel.text = st_message;
        }
        else if (Vector3.Distance(go_PC.transform.position, transform.position) < fl_activation_distance + 1)
        { // Turn off the panel as we move away
            go_message_panel.SetActive(false);       
        }
    }//-----

}//===========
