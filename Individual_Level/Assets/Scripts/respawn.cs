using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject PC;

    void OnTriggerEnter(Collider collision){
        if(collision.transform.tag == "Player"){
            collision.transform.position = respawnPoint.transform.position;
        }
    }
}
