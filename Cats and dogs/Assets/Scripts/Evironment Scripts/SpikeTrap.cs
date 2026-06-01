using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour
{
    public KeyCardPickup keyCardPickup;

    public PlayerFall playerFall;
    bool routineStarted = false;

    public AudioSource audioSource;
    public AudioClip alarm;
    public AudioClip hostileWarning;

    public GameObject lightOne;
    public GameObject lightTwo;

    public GameObject trapMesh;
    public Collider spikeCollider;


    void Start()
    {
        GetComponent<Renderer>().enabled = false; 

        spikeCollider = GetComponent<Collider>();
        spikeCollider.isTrigger = true;
         lightOne.SetActive(false);
        lightTwo.SetActive(false);

    }
    void Update()
    {
        if(keyCardPickup.card.activeSelf && !routineStarted)
        {     
            StartCoroutine(MoveTrap());
            routineStarted = true;
        }

    }

    IEnumerator MoveTrap()
    {  
        GetComponent<Renderer>().enabled = true;

        spikeCollider = GetComponent<Collider>();
        spikeCollider.isTrigger = false;

        routineStarted = true;
        audioSource.PlayOneShot(alarm);
        audioSource.PlayOneShot(hostileWarning);
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(FlashLights());

            for(int i=0;i <=5; i++)
            {
                if (rb != null)
                {
                    rb.linearVelocity = transform.forward * 15f;
                }

                yield return new WaitForSeconds(0.5f);
            }


    }
    

    IEnumerator FlashLights()
    {   
        while (true)
    {
        lightOne.SetActive(true);
        lightTwo.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        lightOne.SetActive(false);
        lightTwo.SetActive(false);
        yield return new WaitForSeconds(0.4f);
    }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerFall.GameLoss();
        }
    }


}
