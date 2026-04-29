using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class FPController : MonoBehaviour
{   
    public AudioSource audioSource;
    public AudioClip audioClipOne;
    public AudioClip audioClipTwo;
   
    

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;

    public float jumpHeight = 1.5f;
    [Header("Look Settings")]
    public Transform cameraTransform;
    public float lookSensitivity = 0.05f;
    public float verticalLookLimit = 90f;

    [Header("Shooting")]
    public GameObject currentBulletPrefab;
    public GameObject bulletPrefab;
    public Transform gunPoint;

    [Header("Crouch Settings")]
    public float crouchHeight = 1f;
    public float standHeight = 2f;
    public float crouchSpeed = 2.5f;
    private float originalMoveSpeed;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 lookInput;
    public Vector3 velocity;
    private float verticalRotation = 0f;


    [Header("Ammo Types")]

    public WeaponSwitch weaponSwitch;
    public TMP_Text ammoText;
    public int ammo = 22;
    public int secondaryAmmo = 14;
    public int currentAmmo;



    public bool isGameRunning = true;
    public bool isTimeSlowed;
    public bool isGamePaused;
    public bool hasJumped;

    public bool interactPressed;

    public bool hasDashed;

    public InteractCheck interactCheck;
    
    public int jumpCount;

    [Header("Weapon Switching")]
    public bool firstKeyPressed;
    public bool secondKeyPressed;
    
    public GameObject bulletPrefabTwo;

    void Start()
    {
        ammoText.text = $"{ammo}";
        currentBulletPrefab = bulletPrefab;
        currentAmmo = ammo;

    }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        originalMoveSpeed = moveSpeed;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        HandleMovement();
        HandleLook();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {   
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        /*
        if (context.performed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            hasJumped = true;
            doubleJump.jumpCount++;
        }
        */


        if (!context.performed) return;

        if (controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpCount = 1;
            return;
        }

        if (jumpCount == 1 && interactCheck.isDoubleJumpEnabled)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpCount = 2;
        }

    }
    public void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward *
        moveInput.y;
        controller.Move(move * moveSpeed * Time.deltaTime);
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public void HandleLook()
    {
        float mouseX = lookInput.x * lookSensitivity;
        float mouseY = lookInput.y * lookSensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookLimit,
        verticalLookLimit);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (isGameRunning && context.performed && ammo > 0 && !isGamePaused && !interactCheck.inCollider && weaponSwitch.blasterOne.activeSelf)
        {
            Shoot();
            ammo--;
            ammoText.text = $"{ammo}";
            audioSource.PlayOneShot(audioClipOne);
        }

        if (isGameRunning && context.performed && secondaryAmmo > 0 && !isGamePaused && !interactCheck.inCollider && weaponSwitch.blasterTwo.activeSelf)
        {
            Shoot();
            secondaryAmmo--;
            ammoText.text = $"{secondaryAmmo}";
            audioSource.PlayOneShot(audioClipTwo);
        }

        
    }

    private void Shoot()
    {
        if (currentBulletPrefab != null && gunPoint != null && !isGamePaused)
    {
        GameObject bullet = Instantiate(currentBulletPrefab, gunPoint.position, gunPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = gunPoint.forward * 50f;
            Destroy(bullet, 3f);
        }
    }

    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            controller.height = crouchHeight;
            moveSpeed = crouchSpeed;
        }

        else if (context.canceled)
        {
            controller.height = standHeight;
            moveSpeed = originalMoveSpeed;
        }

    }

    public void OnSlowTime(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isTimeSlowed = true;
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isGamePaused = true;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            hasDashed = true;
        }
    }

    public void OnFirstKeyPress(InputAction.CallbackContext context)
    {
       if (context.performed)
        {
            firstKeyPressed = true;
            
        } 
    }

    public void OnSecondKeyPress(InputAction.CallbackContext context)
    {
       if (context.performed)
        {
            secondKeyPressed = true;
          
        } 
    }
    
    
}
    
