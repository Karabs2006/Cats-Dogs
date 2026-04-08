using UnityEngine;
using System.Collections;

public class MoveEndPlatform : MonoBehaviour
{
    public bool reachedLeft;
    public bool reachedRight;


    void Start()
    {
        reachedLeft = true;
        reachedRight = false;
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {   
        while(true){
        if(reachedLeft){
        for(int i = 5; i>=0; i--)
        {
            transform.position = new Vector3(
            transform.position.x + 5f,
            transform.position.y,
            transform.position.z);

            yield return new WaitForSeconds(1f); 

            if(i == 0)
            {
                reachedLeft= false;
                reachedRight = true;
            }
        }
        }


        if(reachedRight){
        for(int i = 5; i>=0; i--)
        {
            transform.position = new Vector3(
            transform.position.x - 5f,
            transform.position.y,
            transform.position.z);

            yield return new WaitForSeconds(1f); 

            if(i == 0)
            {
                reachedLeft= true;
                reachedRight = false;
            }
        }
        }
    }
    }
}
