using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public CharacterController characterController;
    public InteractCheck interactCheck;
    public FPController fPController;
    public float dashSpeed;
    public float dashTime;

    public AudioSource audioSource;
    public AudioClip dashSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fPController.hasDashed && interactCheck.isDashEnabled)
        {
            StartCoroutine(Dash());
        }
    }


    IEnumerator Dash()
    {
        float startTime = Time.time;
        audioSource.PlayOneShot(dashSound);

        while(Time.time < startTime + dashTime)
        {
            fPController.hasDashed = false;
            characterController.Move(transform.forward * dashSpeed * Time.deltaTime);
            
            yield return null;
        }
    }
}

