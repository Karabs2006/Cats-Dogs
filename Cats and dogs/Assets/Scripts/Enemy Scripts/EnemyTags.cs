using TMPro;
using UnityEngine;

public class EnemyTags : MonoBehaviour
{
    public TMP_Text tagCount;
    static public int tagInt;
    public int totalTags;
    public EnemyBulletCheck enemyBulletCheck;

    void Start()
    {
        //tagCount = GameObject.FindWithTag("TagCounter").GetComponent<TMP_Text>();
        tagCount.text = $"{tagInt}";
        totalTags = tagInt;
    }

    static public void ResetScore()
    {
        tagInt = 0;
    }
    
    public void BuyHealth()
    {
        if(tagInt >= 10)
        {
            tagInt -= 10;
            tagCount.text = $"{tagInt}";
            enemyBulletCheck.currentSlider = enemyBulletCheck.upgradedHealthSlider;
            enemyBulletCheck.maxHealth = 50;
            enemyBulletCheck.upgradedHealthSlider.gameObject.SetActive(true);
            enemyBulletCheck.healthSlider.gameObject.SetActive(false);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DogTag")
        {
            tagInt += 3; 
            totalTags = tagInt;
            tagCount.text = $"{tagInt}";
            Destroy(other.gameObject);
        }
    }
}
