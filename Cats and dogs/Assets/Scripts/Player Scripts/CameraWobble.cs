using UnityEngine;

public class CameraWobble : MonoBehaviour
{
    [Header("Wobble Settings")]
    [SerializeField] private float bobbingSpeed = 0.05f;
    [SerializeField] private float bobbingAmountX = 0.01f;
    [SerializeField] private float bobbingAmountY = 0.02f;

    [Header("References")]
    [SerializeField] private FPController fpController;

    [Header("Smoothing")]
    [SerializeField] private float restPositionSmoothSpeed = 10f;

    private float timer;
    private Vector3 defaultLocalPosition;

    void Start()
    {
        defaultLocalPosition = transform.localPosition;
    }

    void Update()
    {
        if (fpController == null)
            return;

        bool isMoving =
            fpController.moveInput.magnitude > 0.1f &&
            fpController.GetComponent<CharacterController>().isGrounded;

        if (isMoving)
        {
            timer += Time.deltaTime * bobbingSpeed;

            float newX = defaultLocalPosition.x +
                         Mathf.Cos(timer * 0.5f) * bobbingAmountX;

            float newY = defaultLocalPosition.y +
                         Mathf.Abs(Mathf.Sin(timer)) * bobbingAmountY;

            transform.localPosition = new Vector3(
                newX,
                newY,
                defaultLocalPosition.z
            );
        }
        else
        {
            timer = 0f;

            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                defaultLocalPosition,
                Time.deltaTime * restPositionSmoothSpeed
            );
        }
    }
}