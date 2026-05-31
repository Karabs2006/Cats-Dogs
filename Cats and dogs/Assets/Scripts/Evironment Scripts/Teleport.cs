using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;

    public AudioSource audioSource;
    public AudioClip audioClip;
    
    public void TeleportPlayer()
    {
        if (player != null && spawnPoint != null)
        {
            CharacterController cc = player.GetComponent<CharacterController>();

            if (cc != null)
                cc.enabled = false;

            player.transform.position = spawnPoint.position;
            audioSource.PlayOneShot(audioClip);
            
            

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

    IEnumerator SoundDelay()
    {
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(audioClip);

    }
}
