using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newScene : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
     {
        SceneManager.LoadScene("FINALLEVEL", LoadSceneMode.Additive);
     }
}
