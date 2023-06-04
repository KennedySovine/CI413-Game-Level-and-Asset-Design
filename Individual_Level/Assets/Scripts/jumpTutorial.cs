using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumpTutorial : MonoBehaviour
{
    public GameObject Tutorial;
    public Text text_panel;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider collision){
        Tutorial.gameObject.SetActive(true);
        text_panel.text = "Press [SPACE] to jump";
    }
    void Update(){
        if (Input.GetKeyDown("space")){
            Tutorial.gameObject.SetActive(false);
        }
    }
}
