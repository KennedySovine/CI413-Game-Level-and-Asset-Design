using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    public void inventoryAdd(GameObject collect){
        items.Add(collect);
    }

    public void inventoryRemove(GameObject collect){
        if (items.Contains(collect)){
            items.Remove(collect);
        }
    }

    public bool inventoryContains(GameObject collect){
        if (items.Contains(collect)){
            return true;
        }
        return false;
    }
}
