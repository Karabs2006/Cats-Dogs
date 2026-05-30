using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour
{   
    public FPController fPController;
    public GameObject card;
    public GameObject door;

    bool routineStarted = false;
    bool inCollider = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(inCollider && fPController.interactPressed && card.activeSelf && !routineStarted)
        {
            StartCoroutine(MoveDoor());
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


}
