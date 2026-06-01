using UnityEngine;

public class CleanStart : MonoBehaviour
{
    void Start()
    {
        PlayerUpgrades.isDashEnabled = false;
        PlayerUpgrades.isDoubleJumpEnabled = false;
        PlayerUpgrades.isHealthEnabled = false;
        PlayerUpgrades.isWeaponFound = false;
    }

   
}
