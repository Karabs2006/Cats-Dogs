using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBulletCheck : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerFall playerFall;
    public int maxHealth = 20;
    public int eliminations = 0;
    public TMP_Text elimText;

    public AudioSource audioSource;
    public AudioClip hurt;

    void Start()
    {
        healthSlider.value = maxHealth;
        elimText.text = $"{elimText}";

    }

    void Update()
    {
        if(healthSlider.value == 0)
        {
            playerFall.GameLoss();
        }
    }
    void OnCollisionEnter(Collision trigger)
    {
        if(trigger.gameObject.CompareTag("EnemyBullet"))
        {
            /*Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            //playerRb.AddForce(transform.forward * 10f, ForceMode.Impulse);
            */

            /*transform.position = new Vector3(
            transform.position.x - 100f,
            transform.position.y,
            transform.position.z
            );
            */
            //ameObject bullet = GameObject.FindWithTag("EnemyBullet");
            //Destroy(bullet);

           Debug.Log("I hate this");

           healthSlider.value --;
        }
            
    }
        

       

    
}

