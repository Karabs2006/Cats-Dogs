using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour
{
   
    public GameObject player;
    public GameObject tagPrefab;
    public EnemyBulletCheck enemyBulletCheck;

    //public Renderer rend;
    //public Material redMaterial;
    //public Material defaultMaterial;
    int damageCount = 0;
    bool hitPlayer;

    bool hasBulletFired;

    public Animator animator;

    void Start()
    {
        
        //rend.material = defaultMaterial;
        
    }

    void Update()
    {   
        MoveEnemy();
    }



    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.4f);
        hasBulletFired = false;
    }

    IEnumerator DamageIndicator()
    {
        //rend.material = redMaterial;
        yield return new WaitForSeconds(0.1f);
        //rend.material = defaultMaterial;

    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(1.5f);
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

    if (distance < 15f) 
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            3.5f * Time.deltaTime
        );

        Vector3 direction = (targetPosition - transform.position).normalized;

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            5f * Time.deltaTime
        );

        animator.SetBool("startWalk", true);
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

        if(collision.gameObject.tag == "PlayerBulletTwo")
        {
            //damageCount++;
            StartCoroutine(DamageIndicator());

            Instantiate(tagPrefab, transform.position, tagPrefab.transform.rotation);

            Destroy(gameObject);
            damageCount = 0;
            StartCoroutine(DamageIndicator());

            enemyBulletCheck.eliminations++;
            enemyBulletCheck.elimText.text = $"{enemyBulletCheck.eliminations}";

            enemyBulletCheck.audioSource.PlayOneShot(enemyBulletCheck.hurt);
        }


        if(collision.gameObject.tag == "Player" && !hitPlayer)
        {
            enemyBulletCheck.currentSlider.value--;
            StartCoroutine(AttackCooldown());

        }

    }
}
