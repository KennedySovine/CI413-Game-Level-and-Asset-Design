using UnityEngine;
using System.Collections;
 
 //Created by Florensie on https://answers.unity.com/questions/811686/how-do-i-toggle-my-pause-menu-with-escape.html
 public class PauseMenu : MonoBehaviour {
     
     public GameObject Canvas;
     public GameObject Camera;
     bool Paused = false;
 
     void Start(){
         Canvas.gameObject.SetActive (false);
     }
 
     void Update () {
         if (Input.GetKeyDown ("escape")) {
             if(Paused == true){
                 Time.timeScale = 1.0f;
                 Canvas.gameObject.SetActive (false);
                 Cursor.visible = false;
                 Screen.lockCursor = true;
                 Paused = false;
             } 
             else {
                 Time.timeScale = 0.0f;
                 Canvas.gameObject.SetActive (true);
                 Cursor.visible = true;
                 Screen.lockCursor = false;
                 Paused = true;
             }
         }
     }
 }    