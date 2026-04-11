using UnityEngine;
using System.Collections;
using TMPro;
using NUnit.Framework;

public class Timer : MonoBehaviour
{   
    public PlayerFall playerFall;
    public TMP_Text timeText;
    public FPController fPController;

    public int timeInt;
    public int timeScript;
   
    void Start()
    {   
        StartCoroutine(Countdown());
        timeText.text = $"{timeInt}";
    }
    

    /*IEnumerator Countdown()
    {
       for(int i = timeInt; i >= 0; i--)
        {  
            //yield return new WaitUntil(() => canContinue == true);

            while(!fPController.isGamePaused){
            timeText.text = $"{i}";
            if(i == 0)
            {
                playerFall.GameLoss();
            }
            
            yield return new WaitForSecondsRealtime(1f);
            }
        }
        }
    */



    public IEnumerator Countdown()
    {
        for (int i = timeInt; i >= 0; i--)
        {
            // Wait if paused
            yield return new WaitWhile(() => fPController.isGamePaused);

            timeText.text = $"{i}";
            timeScript = i;

            if (i == 0)
            {
                playerFall.GameLoss();
            }

            float elapsed = 0f;

            while (elapsed < 1f)
            {
                if (!fPController.isGamePaused)
                {
                    elapsed += Time.unscaledDeltaTime;
                }

                yield return null;
            }
        }
    }
}
