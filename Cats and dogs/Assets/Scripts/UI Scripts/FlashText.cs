using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class FlashText : MonoBehaviour
{
    
    public KeyCardPickup keyCardPickup;
    bool hasRun = false;
    bool stop = false;// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(keyCardPickup.startFlash && !hasRun)
        {
            StartCoroutine(Flash());
        }

        if (stop)
        {
            StopCoroutine(Flash());
        }
    }

     IEnumerator Flash()
    {   
        hasRun = true;

        keyCardPickup.flashObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        keyCardPickup.flashObj.SetActive(false);
        stop = true;
        

    }
}
