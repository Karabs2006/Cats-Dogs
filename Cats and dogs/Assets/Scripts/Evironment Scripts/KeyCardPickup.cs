using UnityEngine;
using System.Collections;

public class KeyCardPickup : MonoBehaviour
{
    public GameObject card;

    public AudioSource audioSource;

    public AudioClip audioClip;

    public GameObject flashObj;
    public bool startFlash = false;

    
    void Start()
    {
        StartCoroutine(Rotate());
        card.SetActive(false);
        flashObj.SetActive(false);
    }

    IEnumerator Rotate()
    {   
        for(int i = 90; i > 0; i += 10 )
        {
        yield return new WaitForSeconds(0.1f);
        transform.eulerAngles = new Vector3(0, i, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            startFlash = true;
            gameObject.SetActive(false);
            card.SetActive(true);
            audioSource.PlayOneShot(audioClip);
            
        }
    }

    
   



}
