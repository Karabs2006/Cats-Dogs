using Unity.VisualScripting;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public FPController fPController;

    public CharacterController characterController;
    public InteractCheck interactCheck;
    bool isRedeemPressed;

    public int jumpCount = 0;

    //public bool onGround = true;

//Mess around with inAir gang

    
    void Start()
    {
        
    }

    void Update()
    {
        /*if(jumpCount == 1 && !characterController.isGrounded && fPController.spacePressed)
        {
            fPController.velocity.y = Mathf.Sqrt(fPController.jumpHeight * -2f * fPController.gravity);
            fPController.hasJumped = true;
            jumpCount++;
            fPController.spacePressed = false;
        }

        if(characterController.isGrounded)
        {
            jumpCount = 0;
            fPController.spacePressed = false;
        }
        */
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            //onGround = true;

        }
    }




}
