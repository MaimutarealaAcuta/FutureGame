using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, Interactable
{
    [SerializeField] private GameObject triggerableObject;
    private Triggerable triggerable;
    [SerializeField] private string interactMessage = "Press E to interact";
    [SerializeField] private bool isInteractable = true;

    [SerializeField] private Material[] materialList = new Material[2]; // 0 - unpressed, 1 - pressed

    public string InteractMessage => interactMessage;
    public bool IsInteractable => isInteractable;

    void Start()
    {
        triggerable = triggerableObject.GetComponent<Triggerable>();
        GetComponent<Renderer>().material = materialList[0];
    }

    public void Interact()
    {
        triggerable?.Trigger();
    }

    public void Highlight()
    {
        GetComponent<Renderer>().material = materialList[1];
    }

    public void Unhighlight()
    {
        GetComponent<Renderer>().material = materialList[0];
    }
}
