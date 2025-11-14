using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform orientation;
    [SerializeField] private float addedDrag = 5;

    private Vector3 moveDirection;
    private Rigidbody rb;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCoolDown;
    [SerializeField] private float airMultiplier;
    bool readForJump;

    [Header("Ground Check")]
    [SerializeField] private float playerHeight = 2;
    [SerializeField] private LayerMask groundLM;
    bool isGrounded;

    //Input
    private InputSystem_Actions playerInput;
    private Vector2 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        playerInput = new InputSystem_Actions();
        playerInput.Player.Enable();
        playerInput.Player.Jump.performed += Jump;
    }

    void Update()
    {
        movementInput = playerInput.Player.Move.ReadValue<Vector2>();

        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLM);

        if(isGrounded)
            rb.linearDamping = addedDrag;
        else
            rb.linearDamping = 0;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        SpeedControl();
    }

    private void PlayerMovement()
    {
        moveDirection = orientation.forward * movementInput.y + orientation.right * movementInput.x;

        rb.AddForce(moveDirection.normalized * moveSpeed * 5f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {            
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
}
