using UnityEngine;
using System.Collections;

public class EnemyShoot_Towards : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform enemyGunPoint;
    public GameObject player;

    public Renderer rend;
    public Material redMaterial;
    public Material defaultMaterial;
    int damageCount = 0;

    bool hasBulletFired;

    void Start()
    {
        //hasBulletFired = false;
        ShootGun();
        //Renderer rend = GetComponent<Renderer>();
        rend.material = defaultMaterial;
       
    }

    void Update()
    {   
       if(!hasBulletFired){
        ShootGun();
       }
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

                Destroy(bullet, 1.5f);
            }

            hasBulletFired = true;
            StartCoroutine(CoolDown());
        }
            }
   
    

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(2f);
        hasBulletFired = false;
    }

    IEnumerator DamageIndicator()
    {
        rend.material = redMaterial;
        yield return new WaitForSeconds(0.1f);
        rend.material = defaultMaterial;

    }


    void MoveEnemy()
    {
        transform.position = Vector3.MoveTowards(
        transform.position,
        player.transform.position,
        2.5f * Time.deltaTime
    );
    }



    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            damageCount++;
            StartCoroutine(DamageIndicator());

            if(damageCount == 3)
            {
                Destroy(gameObject);
                damageCount = 0;
                StartCoroutine(DamageIndicator());
            }
        }
    }
}
