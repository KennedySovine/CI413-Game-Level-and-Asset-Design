// ----------------------------------------------------------------------
// -------------------- 3D 
// -------------------- David Dorrington, UOB Games, 2023
// ----------------------------------------------------------------------
using UnityEngine;

public class DD_Play_Audio : MonoBehaviour
{
    AudioSource audioSourceAttched;
    // Start is called before the first frame update
    void Start()
    {
        audioSourceAttched = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetButton("Fire1")) audioSourceAttched.Play();
    }

}//==========
