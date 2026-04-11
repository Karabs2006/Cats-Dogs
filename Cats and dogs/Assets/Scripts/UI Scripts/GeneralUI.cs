using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GeneralUI : MonoBehaviour
{
    public string levelName;
    public string levelToRestart;
    public GameObject controls;
    public FPController fPController;
    public GameObject pauseMenu;
    bool wasRestartPressed;


    void Start()
    {
        controls.SetActive(false);
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if(fPController.isGamePaused)
        {
            PauseGame();
        }

         if(wasRestartPressed)
        {
            StartCoroutine(RestartGameOnce());
        }
        else if(!wasRestartPressed)
        {
            StopCoroutine(RestartGameOnce());
        }
    }

    public void PauseGame()
    {   
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fPController.lookSensitivity = 0f;
    }
    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(levelName);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {   
        pauseMenu.SetActive(false);
        fPController.isGamePaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fPController.lookSensitivity = 0.6f;
        
    }

    public void LoadControls()
    {
        controls.SetActive(true);
    }

    public void BackToMenu()
    {
        controls.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(levelToRestart);
        wasRestartPressed = true;
        ResumeGame();
    }

     public void LoadHardcore()
    {
        SceneManager.LoadSceneAsync("Level 3_HC");
        Time.timeScale = 1f;
    }

     IEnumerator RestartGameOnce()
    {
        ResumeGame();
        yield return new WaitForSeconds(1f);
        wasRestartPressed = false;
    }



}
