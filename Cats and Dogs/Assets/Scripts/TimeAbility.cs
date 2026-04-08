using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeAbility : MonoBehaviour
{
    public Slider slider; 
    public FPController fPController;
    public bool isTimeUp= false;
    public bool isCountingDown = false;
    public bool isMeterFull = true;
    
    
    

    void Start()
    {
        slider.value = 5;
    }


    void Update()
    {   
        if(fPController.isTimeSlowed && !isCountingDown && isMeterFull)
        {
            StartCoroutine(SlowDown());
        }

        if (isTimeUp)
        {
            StopCoroutine(SlowDown());
            isMeterFull = false;
            StartCoroutine(FillMeter());
            Time.timeScale = 1f;
            isTimeUp = false;

            if (isMeterFull)
            {
                StopCoroutine(FillMeter());
                slider.value = 5;
                isMeterFull = true;

            }
        }
  
    }

   IEnumerator SlowDown()
    {   
        isCountingDown = true;
        fPController.isTimeSlowed = false;
        for(int i = 5; i >= 0; i--)
        {   
            slider.value = i;

            if(i == 0)
            {
            isTimeUp = true;
            isCountingDown = false;
            isMeterFull = false;
            }

            Time.timeScale = 0.3f;

            yield return new WaitForSecondsRealtime(1f);
        }
        
    }


    IEnumerator FillMeter()
    {   
        for(int i = 0; i <= 5; i++)
        {   
            slider.value = i;

            if(i == 5)
            {
                isMeterFull = true;
            }

            yield return new WaitForSecondsRealtime(1f);
        }
    }

}
