using UnityEngine;

public class JumpStart : MonoBehaviour
{
    public FPController fPController;
    public EnemyBulletCheck enemyBulletCheck;
    void Start()
    {
        fPController.isGamePaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fPController.lookSensitivity = 0.6f;

        if(PlayerUpgrades.isHealthEnabled)
        {
            enemyBulletCheck.currentSlider = enemyBulletCheck.upgradedHealthSlider;
            enemyBulletCheck.maxHealth = 50;
            enemyBulletCheck.upgradedHealthSlider.gameObject.SetActive(true);
            enemyBulletCheck.healthSlider.gameObject.SetActive(false);
        }
    }

    
}
