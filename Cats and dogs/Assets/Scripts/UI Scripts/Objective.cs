using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class Objective : MonoBehaviour
{
    public FPController fPController;
    public GameObject objectiveObj;

    public String objectiveText;

    public TMP_Text textField;

    bool isTextFlashing = false;
    

    void Start()
    {
        objectiveObj.SetActive(false);
        textField.text = objectiveText;
        StartCoroutine(FlashText());


    }

    void Update()
    {
        if(fPController.objectivePressed && !isTextFlashing)
        {
            isTextFlashing = true;
            StartCoroutine(FlashText());
            
        }
    }

    IEnumerator FlashText()
    {   
        

        for(int i =0; i < 3; i++)
        {
            fPController.objectivePressed = false;
            objectiveObj.SetActive(true);
            yield return new WaitForSeconds(1f);

            objectiveObj.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        isTextFlashing = false;

    }
}
