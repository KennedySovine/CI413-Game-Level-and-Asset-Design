using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject _pauseMenu;
    public GameObject _pauseButton;
    public GameObject _restartButton;
    public GameObject _resumeButton;
    public GameObject _quitButton;
    
    void QuitGame(){
        Application.Quit();
    }
}
