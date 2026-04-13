using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EnemyShoot : MonoBehaviour
{
   
   public GameObject enemyBulletPrefab;
   public Transform enemyGunPoint;
   int damageCount = 0;

   bool hasBulletFired;

    void Start()
    {
        //hasBulletFired = false;
        ShootGun();
    }

    void Update()
    {   
       if(!hasBulletFired){
        ShootGun();
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
                //rb.AddForce(enemyGunPoint.forward * 1000f); //Adjust force value as needed
                rb.linearVelocity = enemyGunPoint.forward * 30f;
                Destroy(bullet, 1.5f); //delete bullet after 3 seconds

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




    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            damageCount++;
            //StartCoroutine(DamageIndicator());

            if(damageCount == 3)
            {
                Destroy(gameObject);
                damageCount = 0;
                //StartCoroutine(DamageIndicator());
            }
        }
    }
    
}
