using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class ladderClimb : MonoBehaviour {
 
     GameObject playerOBJ;
     bool canClimb = false;
     float speed = 1;
 
     void OnCollisionEnter(Collision coll)
     {
         if (coll.gameObject.tag == "Player")
         {
             canClimb = true;
             playerOBJ = coll.gameObject;
         }
     }
 
     void OnCollisionExit(Collision coll2)
     {
         if (coll2.gameObject.tag == "Player")
         {
             canClimb = false;
             playerOBJ = null;
         }
     }
     void Update()
     {
         if (canClimb)
         {
             if (Input.GetKey(KeyCode.W))
             {
                 playerOBJ.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
             }
             if (Input.GetKey(KeyCode.S))
             {
                 playerOBJ.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
             }
         }
     }
 }
