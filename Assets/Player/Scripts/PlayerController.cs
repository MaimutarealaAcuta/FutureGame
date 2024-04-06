using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    private bool isSprinting = false;
    [SerializeField] private Transform playerCamera;   

    private PlayerInput playerInput;

    [SerializeField] private Transform groundCheck;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded = true;

    // camera vertical rotation
    private float verticalRotation = 0f;

    Vector3 velocity;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity = -9.81f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.jumpHandler += Jump;
        playerInput.sprintHandler += ToggleSprint;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSprinting)
        {
            // increase speed to sprint speed over time
            speed = Mathf.Lerp(speed, sprintSpeed, 0.1f);
        }
        else
        {
            // decrease speed to walk speed over time
            speed = Mathf.Lerp(speed, walkSpeed, 0.1f);
        }

        // player movement
        Vector3 direction = new Vector3(playerInput.Horizontal, 0, playerInput.Vertical);
        transform.Translate(direction * speed * Time.deltaTime);

        // player rotation
        Vector3 rotation = new Vector3(0, playerInput.MouseHorizontal, 0);
        transform.Rotate(rotation);

        // camera rotation - vertical rotation
        verticalRotation -= playerInput.MouseVertical;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        playerCamera.localEulerAngles = new Vector3(verticalRotation, 0, 0);

        // jumping
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //if (isGrounded && velocity.y < 0) velocity.y = -2.0f;

    }

    public void Jump()
    {
        if (!isGrounded) return;
        isGrounded = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(jumpHeight * -2.0f * gravity), rb.velocity.z);
        rb.velocity = velocity;
    }
    
    public void ToggleSprint()
    {
        isSprinting = !isSprinting;
    }
}
