using UnityEngine;

public class Ammo : MonoBehaviour
{
    public FPController fPController;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            fPController.ammo += 15;
            fPController.ammoText.text = $"{fPController.ammo}";
            Destroy(gameObject);
        }
    }
}
