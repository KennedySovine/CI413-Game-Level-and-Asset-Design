using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_OnHit : MonoBehaviour
{
    private void OnControllerColliderHit (ControllerColliderHit cc_hit)
    {
        if (cc_hit.gameObject.CompareTag("Enemy"))
        {
            cc_hit.gameObject.SetActive(false);
        }
    }
}
