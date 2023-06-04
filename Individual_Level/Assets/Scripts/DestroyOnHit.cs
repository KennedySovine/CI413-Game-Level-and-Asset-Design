using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
     {
        Destroy(this);
     }
}
