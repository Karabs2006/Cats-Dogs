using UnityEngine;

public class AmmoTwo : MonoBehaviour
{
    public FPController fPController;
    public AudioSource audioSource;
    public AudioClip reload;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            fPController.secondaryAmmo += 8;
            
            if(fPController.weaponSwitch.blasterTwo.activeSelf)
            {
                fPController.ammoText.text = $"{fPController.secondaryAmmo}";
            }
            
            audioSource.PlayOneShot(reload);
            Destroy(gameObject);
        }
    }
}
