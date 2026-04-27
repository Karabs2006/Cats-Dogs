using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject tagPrefab;
    public EnemyBulletCheck enemyBulletCheck;

    public Renderer rend;
    public Material redMaterial;
    public Material defaultMaterial;

    public Slider bossSlider;
    int damageValue = 100;
    bool hitPlayer;
    public bool dropWalls = false;

    public GameObject walls;

    bool hasBulletFired;

    void Start()
    {
        rend.material = defaultMaterial;
        bossSlider.value = damageValue;
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
        float distance = Vector3.Distance(transform.position, player.transform.position);

    if (distance < 15f) 
    {
        transform.position = Vector3.MoveTowards(
        transform.position,
        player.transform.position,
        2.5f * Time.deltaTime
        );
    }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            damageValue-=5;
            bossSlider.value = damageValue;
            StartCoroutine(DamageIndicator());

            if(damageValue <= 0)
            {
                Instantiate(tagPrefab, transform.position, tagPrefab.transform.rotation);
                walls.SetActive(false);

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
            bossSlider.value = damageValue;
            StartCoroutine(DamageIndicator());

            if(damageValue <= 0)
            {
                Instantiate(tagPrefab, transform.position, tagPrefab.transform.rotation);
                walls.SetActive(false);

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
