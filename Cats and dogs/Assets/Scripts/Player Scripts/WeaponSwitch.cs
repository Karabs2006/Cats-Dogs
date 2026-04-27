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
