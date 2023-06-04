// ----------------------------------------------------------------------
// -------------------- 3D Hit Marker
// -------------------- David Dorrington, 2023
// ----------------------------------------------------------------------
using UnityEngine;

public class DD_Marker : MonoBehaviour
{
    public float fl_lifetime = 0.5f; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, fl_lifetime);
    }   
}
