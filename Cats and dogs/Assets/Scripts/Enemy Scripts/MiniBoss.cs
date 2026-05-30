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

    public Animator animator;
    int damageValue = 60;
    bool hitPlayer;
    bool hasBulletFired;

    bool moveStarted = false;


    public AudioSource audioSource;
    public AudioClip audioClip;



    public Renderer rend;
    public Material redMaterial;
    public Material defaultMaterial;

    bool hasPlayedAlertSound;
    

    void Start()
    {
        //Renderer rend = GetComponent<Renderer>();
        rend.material = defaultMaterial;
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
        yield return new WaitForSeconds(9f);
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

    bool isMoving = distance < 15f && doorButton.isDoorOpened;

    if (isMoving)
    {
        moveStarted = true;

        // Play alert sound once
        if (!hasPlayedAlertSound)
        {
            audioSource.PlayOneShot(audioClip);
            hasPlayedAlertSound = true;
        }

        // Start walking sound loop
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

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

    else
    {
        hasPlayedAlertSound = false;

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
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

                Destroy(bullet, 0.5f);
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
                
                StartCoroutine(Death());
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
                

                StartCoroutine(Death());
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


        IEnumerator Death()
        {
            animator.SetBool("hasDied", true);
            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);

        }

    }
}
