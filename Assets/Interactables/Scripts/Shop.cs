using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, Interactable
{
    private string interactMessage = "Buy poison";
    public string InteractMessage => interactMessage;

    [SerializeField]
    private bool isInteractable = true;

    public bool IsInteractable => isInteractable;

    private LevelManager levelManager;


    public void Highlight()
    {
        if (!isInteractable) return;
        
        if (!levelManager.CheckObjective("coins"))
        {
            interactMessage = "Find 2 coins";
            isInteractable = false;
            return;
        }

        interactMessage = "Buy poison";
    }

    public void Interact()
    {
        if (!isInteractable) return;
        interactMessage = "";
        isInteractable = false;
        levelManager.ProgressObjective("poison");
        
    }

    public void Unhighlight()
    {
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
}
