using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour, Interactable
{
    private string interactMessage = "Kill the king";
    public string InteractMessage => interactMessage;

    [SerializeField]
    private bool isInteractable = true;
    public bool IsInteractable => isInteractable;

    private LevelManager levelManager; 
    private UIMessageScript ui;
    
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        ui = FindObjectOfType<UIMessageScript>();
    }

    public void Interact()
    {
        if (!isInteractable) return;
        interactMessage = "";
        isInteractable = false;
        StartCoroutine(KillTheKing());
    }

    public void Highlight()
    {
        if (!isInteractable) return;

        if (!levelManager.CheckObjective("poison"))
        {
            interactMessage = "Buy poison";
            return;
        }

        interactMessage = "Kill the king";
    }

    public void Unhighlight()
    {
        return;
    }

    IEnumerator KillTheKing()
    {
        ui.ShowMessage("The king is dead. Long live the king!");
        yield return new WaitForSeconds(5);
        ui.HideMessage();
        levelManager.FinishLevel("Medieval");
    }
}
