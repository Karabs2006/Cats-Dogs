using UnityEngine;
using System.Collections;

public class KeyCardPickup : MonoBehaviour
{
    public GameObject card;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Rotate());
        card.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
            gameObject.SetActive(false);
            card.SetActive(true);
        }
    }
}
