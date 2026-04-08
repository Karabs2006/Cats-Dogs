using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            //playerRb.AddForce(transform.forward * 10f, ForceMode.Impulse);

            player.transform.position = new Vector3(
            player.transform.position.x - 100f,
            player.transform.position.y,
            player.transform.position.z
            );
            

            if(playerRb != null)
            {
                
            }
        }

    
    }
}
