using UnityEngine;

public class ScoreReset : MonoBehaviour
{
    void Awake()
    {
        EnemyTags.ResetScore();
    }

}
