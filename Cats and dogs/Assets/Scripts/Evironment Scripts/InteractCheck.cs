using UnityEngine;

public class InteractCheck : MonoBehaviour
{
    public FPController fPController;
    public GameObject upgradesMenu;
    public EnemyTags enemyTags;

    public GameObject healthBtn;
    public GameObject dashBtn;

    public GameObject doubleJumpBtn;

    public bool isDashEnabled = false;
    public bool inCollider = false;

    public bool isDoubleJumpEnabled = false;
    bool isBackPressed;

    
    void Start()
    {
        upgradesMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if(fPController.interactPressed && inCollider)
            {   
                isBackPressed = false;
                upgradesMenu.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                fPController.lookSensitivity = 0f;
                fPController.interactPressed = false;
                inCollider = true;
            }

        if (isBackPressed)
        {
            inCollider = false;
        }
    }

    public void Back()
    {
        isBackPressed = true;
        upgradesMenu.SetActive(false);
        fPController.isGamePaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fPController.lookSensitivity = 0.6f;
        
    }

    public void RemainFalse()
    {
        
    }

    public void ExtraHealth()
    { 
        if(enemyTags.publicTagInt >= 10)
        {
        enemyTags.BuyHealth();
        Destroy(healthBtn);
        }
    }

    public void EnableDash()
    {   
        if(enemyTags.publicTagInt >= 15)
        {
        isDashEnabled = true;
        enemyTags.BuyDash();
        Destroy(dashBtn);
        }
    }

    public void EnableDoubleJump()
    {
        if(enemyTags.publicTagInt >= 15)
        {
            enemyTags.BuyDoubleJump();
            isDoubleJumpEnabled = true;
            Destroy(doubleJumpBtn);
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           inCollider = true;
        }
    }
}
