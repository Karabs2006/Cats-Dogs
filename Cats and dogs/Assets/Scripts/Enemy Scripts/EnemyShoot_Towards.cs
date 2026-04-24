using UnityEngine;
using System.Collections;

public class EnemyShoot_Towards : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform enemyGunPoint;
    public GameObject player;
    public GameObject tagPrefab;
    public EnemyBulletCheck enemyBulletCheck;

    public Renderer rend;
    public Material redMaterial;
    public Material defaultMaterial;
    int damageCount = 0;
    bool hitPlayer;

    bool hasBulletFired;

    void Start()
    {
        //hasBulletFired = false;
        //ShootGun();
        //Renderer rend = GetComponent<Renderer>();
        rend.material = defaultMaterial;
        //tagPrefab = GameObject.FindWithTag("DogTag");
       
    }

    void Update()
    {   
       /*if(!hasBulletFired){
        ShootGun();
       }
       */
        MoveEnemy();
    }


    public void ShootGun()
    {
        /*if (enemyBulletPrefab != null && enemyGunPoint != null)
        {
            GameObject bullet = Instantiate(enemyBulletPrefab ,enemyGunPoint.position, enemyGunPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                //rb.AddForce(enemyGunPoint.forward * 1000f); //Adjust force value as needed
                rb.linearVelocity = enemyGunPoint.forward * 30f;
                Destroy(bullet, 1.5f); //delete bullet after 3 seconds

            }

            hasBulletFired = true;
            StartCoroutine(CoolDown());

        }
        */


        if (enemyBulletPrefab != null && enemyGunPoint != null && player != null)
        {
            GameObject bullet = Instantiate(enemyBulletPrefab, enemyGunPoint.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direction = (player.transform.position - enemyGunPoint.position).normalized;
                rb.linearVelocity = direction * 30f;

                Destroy(bullet, 1f);
            }

            hasBulletFired = true;
            StartCoroutine(CoolDown());
        }
            }
   
    

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.4f);
        hasBulletFired = false;
    }

    IEnumerator DamageIndicator()
    {
        rend.material = redMaterial;
        yield return new WaitForSeconds(0.1f);
        rend.material = defaultMaterial;

    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        hitPlayer = false;
    }


    void MoveEnemy()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

    if (distance < 15f) 
    {
        transform.position = Vector3.MoveTowards(
        transform.position,
        player.transform.position,
        3.5f * Time.deltaTime
        );
    }
    }



    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            damageCount++;
            StartCoroutine(DamageIndicator());

            if(damageCount == 3)
            {

                Instantiate(tagPrefab, transform.position, tagPrefab.transform.rotation);

                Destroy(gameObject);
                damageCount = 0;
                StartCoroutine(DamageIndicator());

                enemyBulletCheck.eliminations++;
                enemyBulletCheck.elimText.text = $"{enemyBulletCheck.eliminations}";

                enemyBulletCheck.audioSource.PlayOneShot(enemyBulletCheck.hurt);

              
            }
        }


        if(collision.gameObject.tag == "Player" && !hitPlayer)
        {
            enemyBulletCheck.healthSlider.value--;
            StartCoroutine(AttackCooldown());

        }

    }
}
