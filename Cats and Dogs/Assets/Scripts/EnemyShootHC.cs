using UnityEngine;
using System.Collections;
public class EnemyShootHC : MonoBehaviour
{
public GameObject enemyBulletPrefab;
   public Transform enemyGunPoint;

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
                rb.linearVelocity = enemyGunPoint.forward * 50f;
                Destroy(bullet, 1.5f); //delete bullet after 3 seconds

            }

            hasBulletFired = true;
            StartCoroutine(CoolDown());

        }
    }
   
    
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.8f);
        hasBulletFired = false;
    }
    
}
