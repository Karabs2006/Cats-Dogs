using TMPro;
using UnityEngine;

public class EnemyTags : MonoBehaviour
{
    public TMP_Text tagCount;
    static public int tagInt;
    public int publicTagInt;
    public int totalTags;
    public EnemyBulletCheck enemyBulletCheck;

    void Start()
    {
        //tagCount = GameObject.FindWithTag("TagCounter").GetComponent<TMP_Text>();
        tagCount.text = $"{tagInt}";
        publicTagInt = tagInt;
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
            publicTagInt = tagInt;
            tagCount.text = $"{tagInt}";
            enemyBulletCheck.currentSlider = enemyBulletCheck.upgradedHealthSlider;
            enemyBulletCheck.maxHealth = 50;
            enemyBulletCheck.upgradedHealthSlider.gameObject.SetActive(true);
            enemyBulletCheck.healthSlider.gameObject.SetActive(false);
        }
    }


    public void BuyDash()
    {
        if(tagInt >= 15)
        {
            tagInt -= 15;
            publicTagInt = tagInt;
            tagCount.text = $"{tagInt}";
        }
    }

    public void BuyDoubleJump()
    {
        if(tagInt >= 15)
        {
            tagInt -= 15;
            publicTagInt = tagInt;
            tagCount.text = $"{tagInt}";
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DogTag")
        {
            tagInt += 3;
            publicTagInt = tagInt;
            totalTags = tagInt;
            tagCount.text = $"{tagInt}";
            Destroy(other.gameObject);
        }
    }



}
