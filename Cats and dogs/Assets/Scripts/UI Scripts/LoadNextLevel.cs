using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadNextLevel : MonoBehaviour
{
    public string nextLevelName;
    public string levelToRestart;
    public bool reachedEndPlatform = false;
    public GameObject winningScreen;
    public AudioSource winningAudioSource;
    public AudioClip winSound;
    public AudioSource backgroundAudioSource;
    public TMP_Text orbsLeft;
    public TMP_Text playerTimeLeft;
    public FPController fPController;
    public GameObject counters;

    public Timer timer;
   
    void Start()
    {
        winningScreen.SetActive(false);
    }

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(nextLevelName);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(levelToRestart);
        Time.timeScale = 1f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {   
            winningScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            winningAudioSource.PlayOneShot(winSound);
            backgroundAudioSource.Stop();
            reachedEndPlatform = true;
            StopCoroutine(timer.Countdown());
        
            playerTimeLeft.text = $"{timer.timeScript}";
            orbsLeft.text =$"{fPController.ammo}";
            counters.SetActive(false);
            fPController.lookSensitivity = 0f;
            fPController.isGameRunning = false;

        }

    }





}
