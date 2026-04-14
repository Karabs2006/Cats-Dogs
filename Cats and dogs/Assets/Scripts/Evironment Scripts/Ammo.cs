using UnityEngine;

public class Ammo : MonoBehaviour
{
    public FPController fPController;
    public AudioSource audioSource;
    public AudioClip reload;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            fPController.ammo += 15;
            fPController.ammoText.text = $"{fPController.ammo}";
            audioSource.PlayOneShot(reload);
            Destroy(gameObject);
        }
    }
}
