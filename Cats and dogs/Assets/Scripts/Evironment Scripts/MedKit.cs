using UnityEngine;

public class MedKit : MonoBehaviour
{
    public EnemyBulletCheck enemyBulletCheck;


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enemyBulletCheck.healthSlider.value = enemyBulletCheck.maxHealth;
            Destroy(gameObject);
        }
    }
}
