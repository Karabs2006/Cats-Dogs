using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour
{   
    
    public GameObject platform;
    public Transform left;
    public Transform right;
    Coroutine currentCoroutine;
   
    void Start()
    {
        StartCoroutine(MoveLeft());
    }

    void Update()
    {
        
    }

    IEnumerator InitialMove()
    {   
        for(int i = 3; i>=0; i--)
        {
            platform.transform.position = new Vector3(
                platform.transform.position.x - 5f,
                platform.transform.position.y,
                platform.transform.position.z);

            yield return new WaitForSeconds(1f);

        }
    }


    IEnumerator MoveRight()
    {   
        /*StopCoroutine(MoveLeft());
        for(int i = 10; i>=0; i--)
        {
            platform.transform.position = new Vector3(
                platform.transform.position.x +5f,
                platform.transform.position.y,
                platform.transform.position.z);           
        }
        */
        while(Vector3.Distance(transform.position, right.position) > 0.01f)
        {
        yield return new WaitForSeconds(1f);
        // Calculate the distance the object should move this frame
        float step = 1000* Time.deltaTime; 

        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, right.position, step);
        }
    }

    IEnumerator MoveLeft()
    {
        /*for(int i = 20; i>=0; i--)
        {
            StopCoroutine(MoveRight());
            platform.transform.position = new Vector3(
                platform.transform.position.x -3f,
                platform.transform.position.y,
                platform.transform.position.z);

            yield return new WaitForSeconds(1f);
        }
        */
        while(Vector3.Distance(transform.position, left.position) > 0.01f)
        {
        yield return new WaitForSeconds(1f);
        // Calculate the distance the object should move this frame
        float step = 1000* Time.deltaTime; 

        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, left.position, step);
        }


    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Left")
        {   
            StartCoroutine(MoveRight());
        }

        if (other.tag == "Right")
        {   
            StartCoroutine(MoveLeft());
        }

    }

    
}