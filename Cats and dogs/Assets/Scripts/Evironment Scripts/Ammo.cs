using UnityEngine;

public class Ammo : MonoBehaviour
{
    public FPController fPController;
    public AudioSource audioSource;
    public AudioClip reload;
    public WeaponSwitch weaponSwitch;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            fPController.ammo += 15;
            
            if(fPController.weaponSwitch.blasterOne.activeSelf)
            {
                fPController.ammoText.text = $"{fPController.ammo}";
            }
            
            audioSource.PlayOneShot(reload);
            Destroy(gameObject);
        }
    }
}
