using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelName;
    public GameObject controls;

    void Start()
    {
        controls.SetActive(false);
    }

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(levelName);
        Time.timeScale = 1f;
    }

    public void LoadHardcore()
    {
        SceneManager.LoadSceneAsync("Level 3_HC");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadControls()
    {
        controls.SetActive(true);
    }

    public void BackToMenu()
    {
        controls.SetActive(false);
    }

}


