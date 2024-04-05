using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, Interactable
{
    [SerializeField] private Triggerable triggerable;
    [SerializeField] private string interactMessage = "Press E to interact";
    [SerializeField] private bool isInteractable = true;

    public string InteractMessage => interactMessage;
    public bool IsInteractable => isInteractable;

    public void Interact()
    {
        triggerable?.Trigger();
    }

    public void Highlight()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void Unhighlight()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
