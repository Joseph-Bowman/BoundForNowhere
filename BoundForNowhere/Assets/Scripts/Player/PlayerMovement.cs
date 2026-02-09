using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")] //Controls the players movement including speed and drag. //The orientation is the current facing direction of the player
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform orientation;
    [SerializeField] private float addedDrag = 5;

    //Player body and direction control
    private Vector3 moveDirection;
    private Rigidbody rb;

    [Header("Jump")] //The jumps settings including force and cool down
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCoolDown;
    [SerializeField] private float airMultiplier;
    bool readyForJump = true;

    [Header("Ground Check")] // The layer mask is used to determine what counts as the ground
    [SerializeField] private float playerHeight = 2;
    [SerializeField] private LayerMask groundLM;
    bool isGrounded;

    //Input
    private InputSystem_Actions playerInput;
    private Vector2 movementInput;

    void Start() { rb = GetComponent<Rigidbody>(); }

    //Enables the players input
    private void OnEnable()
    {
        playerInput = new InputSystem_Actions();

        playerInput.Player.Enable();
        playerInput.Player.Jump.performed += Jump; //Links the player jump input to the jump function
    }

    //disables the players input
    private void OnDisable()
    {
        playerInput.Player.Jump.performed -= Jump; //unlinks the player jump input to the jump function
        playerInput.Player.Disable();
    }

    //Handles Player input and ground check as they are not impacted by the fps
    void Update()
    {
        movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLM); // Checks the ground using a raycast from the player position using the height plus a small amount extra so no matter how tall the player is it works

        if(isGrounded) { rb.linearDamping = addedDrag; }
        else { rb.linearDamping = 0; }
    }

    //Handles the player movement and speed so its not dependant on fps
    private void FixedUpdate()
    {
        PlayerMovement();
        SpeedControl();
    }

    //Handles the player movement 
    private void PlayerMovement()
    {
        moveDirection = orientation.forward * movementInput.y + orientation.right * movementInput.x; //getting the orientation and adding the player input to find the direction

        if(isGrounded) { rb.AddForce(moveDirection.normalized * moveSpeed * 5f, ForceMode.Force); } // If grounded it adds force to the player so they can move according to the movement direction vector
        else if(!isGrounded) { rb.AddForce(moveDirection.normalized * moveSpeed * 5f * airMultiplier, ForceMode.Force); }  // If not grounded it adds force as before but adds an air multiplier 
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); //Determines the velocity by normalizing both vectors current velocity

        if (flatVel.magnitude > moveSpeed) //Checks if the current velocity is more than move speed
        {
            //If so we set a new velocity using the current velocity and the player speed and apply it to the player
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        //If the jump is not performed return the logic // Checks for input 
        if (!context.performed) return;

        //Checks if the player is ready for the jump and on the ground
        if (readyForJump && isGrounded)
        {            
            //Sets the player jump to false so they cant jump forever // Adds velocity and force to the character and invokes the reset jump function
            readyForJump = false;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            Invoke(nameof(ResetJump), jumpCoolDown);
        }
    }

    //Sets ready to jump to true so the player can jump once grounded
    void ResetJump() { readyForJump = true; }
}
