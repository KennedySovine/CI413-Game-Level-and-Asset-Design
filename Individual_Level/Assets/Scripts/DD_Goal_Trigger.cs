// ----------------------------------------------------------------------
// -------------------- 3D Goal Trigger
// -------------------- David Dorrington, UoB, 2023
// ----------------------------------------------------------------------
using UnityEngine;

public class DD_Goal_Trigger : MonoBehaviour
{
    public bool bl_goal_triggered = false;
    public GameObject go_PC;

    // Start is called before the first frame update
    void Start()
    {
        if (!go_PC)
            go_PC = GameObject.FindGameObjectWithTag("Player" );        
    }//----

    private void OnTriggerEnter(Collider _object_touching)
    {
        if(!bl_goal_triggered && _object_touching.CompareTag("Player"))
                bl_goal_triggered=true;     
    }//-----

}//==========
