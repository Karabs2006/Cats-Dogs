using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour
{   
    public FPController fPController;
    public GameObject card;
    public GameObject door;

    public AudioSource audioSource;

    public AudioClip rewardAudio;
    public AudioClip failAudio;

    bool routineStarted = false;
    bool inCollider = false;

    bool hasSoundPlayed;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(inCollider && fPController.interactPressed && card.activeSelf && !routineStarted)
        {
            fPController.interactPressed = false;
            StartCoroutine(MoveDoor());
            StartCoroutine(PlayAudio(rewardAudio));

        }



        if(inCollider && fPController.interactPressed && !card.activeSelf)
        {
            fPController.interactPressed = false;
            StartCoroutine(PlayAudio(failAudio));
        }

    
    }

    IEnumerator MoveDoor()
    {
        Vector3 startPos = door.transform.position;
        Vector3 endPos = startPos + Vector3.left * 3f;

        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            door.transform.position = Vector3.Lerp(
                startPos,
                endPos,
                elapsed / duration
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        door.transform.position = endPos;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inCollider = false;
        }
    }

    IEnumerator PlayAudio(AudioClip audioClip)
    {
        if (!hasSoundPlayed)
        {
            audioSource.PlayOneShot(audioClip);
            hasSoundPlayed = true;
        }

        yield return new WaitForSeconds(audioClip.length);
        hasSoundPlayed = false;


    }

}
