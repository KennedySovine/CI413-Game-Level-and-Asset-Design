using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponTutorial : MonoBehaviour
{
    public GameObject Tutorial;
    public Text text_panel;
    private GameObject weapon;
    // Start is called before the first frame update
    void Start(){
        weapon = GameObject.FindWithTag("Weapon");
    }
    void OnTriggerEnter(Collider collision){
        Tutorial.gameObject.SetActive(true);
        text_panel.text = "Press [F] to pick up the Bow and Arrows.";
    }
    void Update(){
        if(weapon.GetComponent< KIS_Object_Carry>().bl_carrying){
            text_panel.text = "Press left click to shoot";
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0)){;
            Tutorial.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider collision){
        Tutorial.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
