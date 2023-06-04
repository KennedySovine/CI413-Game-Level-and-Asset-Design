using UnityEngine;
using UnityEngine.SceneManagement;

//Created by: https://medium.com/nerd-for-tech/creating-the-pause-menu-in-unity-e48277abdf8e

public class MainMenu : MonoBehaviour
{
    public GameObject _pauseMenu;
    public GameObject _restartButton;
    public GameObject _resumeButton;
    public GameObject _quitButton;
    
    public void QuitGame(){
        Application.Quit();
    }
    public void ResumeButton(){
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
        Screen.lockCursor = true;
    }
    //Credited to: JScotty from https://answers.unity.com/questions/1261937/creating-a-restart-button.html
    public void RestartButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
