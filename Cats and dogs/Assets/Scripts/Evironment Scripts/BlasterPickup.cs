using System.Collections;
using UnityEngine;

public class BlasterPickup : MonoBehaviour
{   
    public WeaponSwitch weaponSwitch;
    public bool blasterCollected = false;

    int angle = 90;
    void Start()
    {
        StartCoroutine(Rotate());
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameObject.SetActive(false);
            weaponSwitch.weaponUI.SetActive(true);
            blasterCollected = true;
            }
    }

    IEnumerator Rotate()
    {   
        for(int i = 90; i > 0; i += 10 )
        {
        yield return new WaitForSeconds(0.1f);
        transform.eulerAngles = new Vector3(0, i, 0);
        }
    }


}
