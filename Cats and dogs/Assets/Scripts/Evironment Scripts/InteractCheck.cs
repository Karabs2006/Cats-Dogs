using UnityEngine;

public class InteractCheck : MonoBehaviour
{
    public FPController fPController;
    public GameObject upgradesMenu;
    public EnemyTags enemyTags;

    public GameObject healthBtn;

    bool inCollider = false;
    
    void Start()
    {
        upgradesMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if(fPController.interactPressed && inCollider)
            {
                upgradesMenu.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                fPController.lookSensitivity = 0f;
                fPController.interactPressed = false;
                inCollider = false;
            }
    }

    public void Back()
    {
        upgradesMenu.SetActive(false);
        fPController.isGamePaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fPController.lookSensitivity = 0.6f;
        
    }

    public void ExtraHealth()
    {
        enemyTags.BuyHealth();
        Destroy(healthBtn);
    }




    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           inCollider = true;
        }
    }
}
