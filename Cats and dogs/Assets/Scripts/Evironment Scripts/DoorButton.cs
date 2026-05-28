using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DoorButton : MonoBehaviour
{
    public FPController fPController;

    public GameObject questionObject;
    public TMP_InputField myInputField;
    public Animator animator;

    string input;

    bool inDoorTrigger;
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

        }

       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inDoorTrigger = true;
        }
    }


    public void ReadInput(string s)
    {
        myInputField.text = s;
        Debug.Log(s);
        
        if (s.Contains("watchdog", System.StringComparison.OrdinalIgnoreCase))
        {
            animator.SetBool("qOneSolved", true);
            Close();
        }
    }


    public void Close()
    {
        questionObject.SetActive(false);
        fPController.isGamePaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fPController.lookSensitivity = 0.6f;
        inDoorTrigger = false;

    }
}
