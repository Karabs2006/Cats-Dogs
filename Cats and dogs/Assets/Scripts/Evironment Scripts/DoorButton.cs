using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DoorButton : MonoBehaviour
{
    public FPController fPController;

    
    public GameObject questionObject;
    public TMP_InputField myInputField;
    public Animator animator;
    public string answer;

    public GameObject doorCollider;

    bool inDoorTrigger;
    public  bool isDoorOpened = false;
    void Start()
    {
        questionObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(fPController.interactPressed && inDoorTrigger)
        {
            questionObject.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fPController.lookSensitivity = 0f;
            fPController.interactPressed = false;
            inDoorTrigger = true;
            fPController.isGameRunning = false;

        }

       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inDoorTrigger = true;
        }
    }
    

     void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inDoorTrigger = false;
        }
    }

    public void Close()
    {
        questionObject.SetActive(false);
        fPController.isGamePaused = false;
        fPController.interactPressed = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fPController.lookSensitivity = 0.6f;
        inDoorTrigger = false;
        fPController.isGameRunning = true;
        

    }


    public void CheckAnswer()
    {
        if (myInputField.text.Contains(answer, System.StringComparison.OrdinalIgnoreCase))
        {   
            questionObject.SetActive(false);
            animator.SetBool("qOneSolved", true);
            Close();
            StartCoroutine(OpenDelay(doorCollider));
            fPController.interactPressed = false;

        }
    }

    IEnumerator OpenDelay(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
        isDoorOpened = true;

    }
}
