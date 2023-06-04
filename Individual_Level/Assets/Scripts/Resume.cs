using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject _pauseMenu;
    public GameObject _pauseButton;
    public GameObject _restartButton;
    public GameObject _resumeButton;
    public GameObject _quitButton;

    void ResumeGame(){

    Time.timeScale = 1.0f;
    _pauseMenu.SetActive(false);
     _pauseButton.SetActive(true);
    }
}
