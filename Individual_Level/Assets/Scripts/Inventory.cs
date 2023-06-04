using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Collectable> inven = new List<Collectable>();

    public void inventoryAdd(Collectable collect){
        inven.Add(collect);
    }

    public void inventoryRemove(Collectable collect){
        if (inven.Contains(collect)){
            inven.Remove(collect);
        }
    }

    public bool Check(Collectable collect){
        if (inven.Contains(collect)){
            return true;
        }
        return false;
    }
}
