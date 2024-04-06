using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float minInteractDistance = 2f;
    private Interactable currentGazeTarget;

    private PlayerInput playerInput;
    private UIInteractScript ui;

    private bool interactionEnabled = true;
    
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.interactHandler += Interact;

        ui = FindObjectOfType<UIInteractScript>();
    }

    private void Update()
    {
        if (!interactionEnabled) return;
        Look();
    }


    void Look()
    {
        RaycastHit target;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out target, 100) && target.distance <= minInteractDistance)
        {
            Interactable targetObj = target.collider.gameObject.GetComponent<Interactable>();
            if (targetObj != null && targetObj != currentGazeTarget)
            {
                if (currentGazeTarget != null) currentGazeTarget.Unhighlight();
                currentGazeTarget = targetObj;
                currentGazeTarget.Highlight();
                ui.ShowMessage(targetObj.InteractMessage);
            }
        }
        else
        {
            if (currentGazeTarget != null) currentGazeTarget.Unhighlight();
            currentGazeTarget = null;
            ui.HideMessage();
        }
    }

    void Interact()
    {
        currentGazeTarget?.Interact();
    }

    public void switchInteraction()
    {
        interactionEnabled = !interactionEnabled;
    }
}
