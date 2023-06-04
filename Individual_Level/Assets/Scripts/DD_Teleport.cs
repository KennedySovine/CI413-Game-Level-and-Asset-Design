
using UnityEngine;
using UnityEngine.UI;

public class DD_Teleport : MonoBehaviour
{
    // ---------------------------------------------------------------------
    public Transform tf_Teleport_Target;
    private Transform tf_PC;

    // Use this for initialization
    void Start()
    {
       if(!tf_PC) tf_PC = GameObject.FindWithTag("Player").transform;   

    }//--------

    public void OnTriggerEnter (Collider collider){
        tf_PC.transform.position = tf_Teleport_Target.transform.position;
    }

}//=========
