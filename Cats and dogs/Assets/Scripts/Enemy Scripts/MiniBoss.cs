using UnityEngine;
using System.Collections;

public class MiniBoss : MonoBehaviour
{
     public GameObject player;
    public GameObject tagPrefab;
    public EnemyBulletCheck enemyBulletCheck;

    public GameObject enemyBulletPrefab;
    public Transform enemyGunPoint;

    public DoorButton doorButton;
    int damageValue = 60;
    bool hitPlayer;
    bool hasBulletFired;

    bool moveStarted = false;
    

    void Start()
    {
        
    }

    void Update()
    {   
        MoveEnemy();

        if(moveStarted && !hasBulletFired)
        {
            ShootGun();
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(3f);
        hasBulletFired = false;
    }

    IEnumerator DamageIndicator()
    {
        
        yield return new WaitForSeconds(0.1f);
       

    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(2f);
        hitPlayer = false;
    }


    void MoveEnemy()
    {   
        
        Vector3 targetPosition = new Vector3(
        player.transform.position.x,
        transform.position.y,
        player.transform.position.z
        );

        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance < 15f && doorButton.isDoorOpened)
        {
            moveStarted = true;

            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                1.2f * Time.deltaTime
            );

            Vector3 direction = (targetPosition - transform.position).normalized;

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                3f * Time.deltaTime
            );
        }
    }


    public void ShootGun()
    {
        if (enemyBulletPrefab != null && enemyGunPoint != null)
        {
            GameObject bullet = Instantiate(enemyBulletPrefab ,enemyGunPoint.position, enemyGunPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
        if (rb != null)
            {
                Vector3 direction = (
                    player.transform.position - enemyGunPoint.position
                ).normalized;

                rb.linearVelocity = direction * 30f;

                Destroy(bullet, 0.8f);
            }

        hasBulletFired = true;
        StartCoroutine(CoolDown());
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            damageValue-=5;
            
            StartCoroutine(DamageIndicator());

            if(damageValue <= 0)
            {
                Instantiate(tagPrefab, transform.position, tagPrefab.transform.rotation);
                
                Destroy(gameObject);
                damageValue = 0;
                StartCoroutine(DamageIndicator());

                enemyBulletCheck.eliminations++;
                enemyBulletCheck.elimText.text = $"{enemyBulletCheck.eliminations}";

                enemyBulletCheck.audioSource.PlayOneShot(enemyBulletCheck.hurt);
                

                
            }
        }

        if(collision.gameObject.tag == "PlayerBulletTwo")
        {
            damageValue-=10;
            
            StartCoroutine(DamageIndicator());

            if(damageValue <= 0)
            {
                Instantiate(tagPrefab, transform.position, tagPrefab.transform.rotation);
                

                Destroy(gameObject);
                damageValue = 0;
                StartCoroutine(DamageIndicator());

                enemyBulletCheck.eliminations++;
                enemyBulletCheck.elimText.text = $"{enemyBulletCheck.eliminations}";

                enemyBulletCheck.audioSource.PlayOneShot(enemyBulletCheck.hurt);

                
            }
        }


        if(collision.gameObject.tag == "Player" && !hitPlayer)
        {
            enemyBulletCheck.currentSlider.value-= 5;
            StartCoroutine(AttackCooldown());

        }

    }
}
