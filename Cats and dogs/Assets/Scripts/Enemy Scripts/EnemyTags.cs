using TMPro;
using UnityEngine;

public class EnemyTags : MonoBehaviour
{
    public TMP_Text tagCount;
    static int tagInt =0;
    void Start()
    {
        tagCount = GameObject.FindWithTag("TagCounter").GetComponent<TMP_Text>();
        tagCount.text = $"{tagInt}";

    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            tagInt+= 3; 
            tagCount.text = $"{tagInt}";
            Destroy(gameObject);
        }
    }
}
