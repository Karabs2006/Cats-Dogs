using UnityEngine;

public class MedKit : MonoBehaviour
{
    public EnemyBulletCheck enemyBulletCheck;


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enemyBulletCheck.currentSlider.value = enemyBulletCheck.maxHealth;
            Destroy(gameObject);
        }
    }
}
