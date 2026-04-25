using UnityEngine;

public class Upgrades : MonoBehaviour
{
    

    public GameObject healthButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpgradeHealth()
    {
        //healthUpgradePressed = true;
        healthButton.SetActive(false);
   
    }
}
