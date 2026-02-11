using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    //Camera input
    InputSystem_Actions playerInput;
    Vector2 mouseInput;

    //Camera movement sensitivity
    [SerializeField] private float sensX, sensY;
    private float yRotation, xRotation;
    [SerializeField] Transform orientation;

    void Start()
    {
        //Locks the mouse and hides it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        //Initialize the input
        playerInput = new InputSystem_Actions();
        playerInput.Player.Enable();
    }

    void Update()
    {
        //sets the input to the current mouse position based on the look value in controls //Times it by the sensitivity to give control over mouse speed
        mouseInput = playerInput.Player.Look.ReadValue<Vector2>() * Time.deltaTime * sensX;

        //Gets the rotation for the look directions up/down-side/side
        yRotation += mouseInput.x;
        xRotation -= mouseInput.y;

        //Clamps the camera to 90 degree on each vector so the player cannot spin the camera indefinitely
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
