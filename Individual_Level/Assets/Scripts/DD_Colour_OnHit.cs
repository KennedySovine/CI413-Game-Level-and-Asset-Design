// ------------------------------------------------------------
//  ---------- Cololour Object on Hit
//  ---------- David Dorrington, UoBGames 23 
// ------------------------------------------------------------

using UnityEngine;



public class DD_Colour_OnHit : MonoBehaviour
{
    // Variables
    public Color col_new = Color.red;

    private void Start()
    {
        print(col_new);
    }

    // check if the Character COntroller has hit Something
    private void OnControllerColliderHit(ControllerColliderHit cc_hit)
    {   
        //Check if what we are hitting has a tag
        if (cc_hit.gameObject.CompareTag("Colourable")) 
        {
            cc_hit.gameObject.GetComponent<Renderer>().material.color = col_new;
        }
    }//-----

}//==========
