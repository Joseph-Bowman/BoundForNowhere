using UnityEngine;

public class CameraController : MonoBehaviour
{
    InputSystem_Actions playerInput;
    Vector2 mouseInput;

    [SerializeField] private float sensX, sensY;
    private float yRotation, xRotation;
    [SerializeField] Transform orientation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        playerInput = new InputSystem_Actions();
        playerInput.Player.Enable();
    }

    void Update()
    {
        mouseInput = playerInput.Player.Look.ReadValue<Vector2>() * Time.deltaTime * sensX;

        yRotation += mouseInput.x;
        xRotation -= mouseInput.y;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
