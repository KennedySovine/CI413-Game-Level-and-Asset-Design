// ----------------------------------------------------------------------
// -------------------- Simple Compass Rotate
// -------------------- David Dorrington, UoB Games, 23
// ----------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;

public class DD_Compass : MonoBehaviour
{
    public Image im_compass;
    public GameObject go_PC;

    // ----------------------------------------------------------------------
    void Start()
    {
       if (!go_PC) go_PC = GameObject.FindWithTag("Player");
    }//-----

    // ----------------------------------------------------------------------
    void Update()
    {
        im_compass.rectTransform.eulerAngles = new Vector3(0, 0, go_PC.transform.eulerAngles.y);
    }//-----

}//==========
