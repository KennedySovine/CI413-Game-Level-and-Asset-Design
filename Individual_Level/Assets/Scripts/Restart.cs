using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Credited to: JScotty from https://answers.unity.com/questions/1261937/creating-a-restart-button.html
public class Restart : MonoBehaviour {
     
         public void RestartGame() {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
         }
     
     }
