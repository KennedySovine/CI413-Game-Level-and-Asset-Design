using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Variables
    private GameObject PC;
    public Collectable item;
    public GameObject oldColor;
    public GameObject newColor;

    //Start
    private void Start(){
        PC = GameObject.FindWithTag("Player");
    }
    void OnTriggerEnter(Collider collision){
        //PC.GetComponent<Inventory>().inventoryAdd(item);

        oldColor.SetActive(false);
        newColor.SetActive(true);
        Destroy(gameObject);
    }
}
