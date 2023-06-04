using UnityEngine;
using System.Collections;
 
 //Code sourced from DiGiaCom-Tech on https://answers.unity.com/questions/1191795/teleport-script-2.html
public class Teleport : MonoBehaviour {
 
     public Transform Destination;       // Gameobject where they will be teleported to
 
     public void OnTriggerEnter(Collider other)
     {
        other.transform.position = Destination.transform.position;
        other.transform.rotation = Destination.transform.rotation;
     }
 }
