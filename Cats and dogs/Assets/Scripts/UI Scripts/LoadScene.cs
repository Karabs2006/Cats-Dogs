using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string scene;
        public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(scene);
        Time.timeScale = 1f;
    }
}
