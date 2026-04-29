using Unity.VisualScripting;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public FPController fPController;
    public BlasterPickup blasterPickup;

    public GameObject weaponUI;
    public GameObject backgroundOne;
    public GameObject backgroundTwo;

    public GameObject blasterOne;
    public GameObject blasterTwo;

    public AudioSource audioSource;
    public AudioClip switchAudio;

    void Start()
    {
        backgroundTwo.SetActive(false);
        blasterTwo.SetActive(false);
        weaponUI.SetActive(false);
    }

    void Update()
    {
        if(blasterPickup.blasterCollected)
        {
            if(fPController.firstKeyPressed)
            {
                audioSource.PlayOneShot(switchAudio);
                backgroundOne.SetActive(true);
                blasterOne.SetActive(true);

                fPController.currentBulletPrefab = fPController.bulletPrefab;
                //fPController.currentAmmo = fPController.ammo;
                fPController.ammoText.text = $"{fPController.ammo}";

                backgroundTwo.SetActive(false);
                blasterTwo.SetActive(false);


                fPController.firstKeyPressed = false;
            }

            if(fPController.secondKeyPressed)
            {
                audioSource.PlayOneShot(switchAudio);
                backgroundOne.SetActive(false);
                blasterOne.SetActive(false);
                
                blasterTwo.SetActive(true);
                backgroundTwo.SetActive(true);

                fPController.secondKeyPressed = false;

                fPController.currentBulletPrefab = fPController.bulletPrefabTwo;
                //fPController.currentAmmo = fPController.secondaryAmmo;
                fPController.ammoText.text = $"{fPController.secondaryAmmo}";
            }
        }
        
    }

}
