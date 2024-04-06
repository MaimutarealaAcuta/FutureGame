using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public Vector2 MousePosition { get; private set; }
    public float MouseHorizontal { get; private set; }    
    public float MouseVertical { get; private set; }

    public delegate void Jump();
    public Jump jumpHandler;

    public delegate void Interact();
    public Interact interactHandler;

    public delegate void ShowObjective();
    public ShowObjective showObjectiveHandler;


    [SerializeField]
    [Range(1.0f,5.0f)]
    private float mouseSensitivity = 1f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MousePosition = Input.mousePosition;
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        MouseHorizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        MouseVertical = Input.GetAxis("Mouse Y") * mouseSensitivity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpHandler?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            interactHandler?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyUp(KeyCode.Tab))
        {
            showObjectiveHandler?.Invoke();
        }
    }
}
