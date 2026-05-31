using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    public GameObject effects;
    public FPController fPController;

    public AudioSource audioSource;
    public AudioClip audioClip;
    bool activate = false;

    bool hasPlayedAlertSound;

    void Start()
    {
        effects.SetActive(false);

       
    }

    void Update()
    {
        if(activate && fPController.interactPressed)
        {
            effects.SetActive(true);

            if (!hasPlayedAlertSound)
            {
                audioSource.PlayOneShot(audioClip);
                hasPlayedAlertSound = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            activate = true;
        }
    }
}
