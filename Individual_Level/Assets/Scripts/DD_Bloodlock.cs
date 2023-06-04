// ----------------------------------------------------------------------
// -------------------- Bloodlock Object Enable / Disable
// -------------------- David Dorrington, UoB Games, 2022
// ----------------------------------------------------------------------

using UnityEngine;

public class DD_Bloodlock : MonoBehaviour
{ // Variables
    public GameObject[] go_activators;
    public GameObject go_target_object;
    public bool bl_enable;

    //---------------------------------------------------------------------------------------
    void Start()
    {
        // Disable the target object if we are to enable it
        if (bl_enable) go_target_object.SetActive(false);
    }//-----

    //---------------------------------------------------------------------------------------
    void Update()
    {
        // local variable of total number of activation objects we started with
        int _in_objects_left = go_activators.Length;

        // loop through the list of activation objects
        foreach (GameObject _object in go_activators)
        {
            // subtract 1 from the total if the gameobject has been destroyed
            if (!_object) _in_objects_left--;
        }

        // Are all the objects destroyed?
        if (_in_objects_left < 1)
        {
            if (bl_enable) // are we enabling or disabling the target object
                go_target_object.SetActive(true);
            else
                go_target_object.SetActive(false);
        }
    }//-----

}//==========