using UnityEngine;

public class TriggerBossFight : MonoBehaviour
{
    public GameObject boss;
    public GameObject walls;
    public BossEnemy bossEnemy;
    void Start()
    {
        boss.SetActive(false);
        walls.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            boss.SetActive(true);
            walls.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
