using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    
    public void TeleportPlayer()
    {
        if (player != null && spawnPoint != null)
        {
            CharacterController cc = player.GetComponent<CharacterController>();

            if (cc != null)
                cc.enabled = false;

            player.transform.position = spawnPoint.position;

            if (cc != null)
                cc.enabled = true;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            TeleportPlayer();
        }
    }
}
