// ----------------------------------------------------------------------
// -------------------- Trigger Object Enable / Disable
// -------------------- David Dorrington, UoB Games, 2023
// ----------------------------------------------------------------------
using UnityEngine;

public class DD_Trigger_Enable_Object : MonoBehaviour
{
    // ----------------------------------------------------------------------   
    public GameObject go_target;
    public GameObject go_key;
    public bool bl_destroy_trigger_when_activated;
    public float fl_delay = 0.5F;
    public bool bl_enable = false;
    private float fl_enable_time;
    private bool bl_triggered;

    // ----------------------------------------------------------------------
    void Start()
    {
        // Set the Target object to Disabled if we are to enable it on the trigger 
        if (bl_enable) go_target.SetActive(false);
    }//-----

    // ----------------------------------------------------------------------
    void Update()
    {
        // If the trigger has been activated swap the target state after the time delay
        if (bl_triggered && Time.time > fl_enable_time)
        {
            if (bl_enable)
                go_target.SetActive(true);
            else
                go_target.SetActive(false);

            //Turn off trigger object & Trigger when complete 
            if (bl_destroy_trigger_when_activated)
            {
                go_key.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }//-----  

    // ----------------------------------------------------------------------
    // Detect if something enters the Trigger
    void OnTriggerEnter(Collider _cl_object_touching)
    {
        // Is the object toucjing the trigger the correct trigger GameObject 
        if (_cl_object_touching.gameObject == go_key)
        {
            // Set the trigger flag
            bl_triggered = true;

            // Set the time delay
            fl_enable_time = Time.time + fl_delay;
        }
    }//-----

}//================

