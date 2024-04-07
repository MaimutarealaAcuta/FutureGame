using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, Interactable
{

    private string interactMessage = "Place envelope";
    public string InteractMessage => interactMessage;

    private bool isInteractable = true;
    public bool IsInteractable => isInteractable;

    private LevelManager levelManager;
    private UIMessageScript ui;

    public void Highlight()
    {

        if (!levelManager.CheckObjective("letter"))
        {
            interactMessage = "RETREIVE THE LETTER";
            isInteractable = false;
            return;
        }
        else
        {
            isInteractable = true;
        }        

        if (!isInteractable) return;
        interactMessage = "Place letter";
    }

    public void Interact()
    {
        if (!isInteractable) return;
        interactMessage = "";
        isInteractable = false;
        StartCoroutine(DeliverTheLetter());
    }

    public void Unhighlight()
    {
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        ui = FindObjectOfType<UIMessageScript>();
    }
    
    IEnumerator DeliverTheLetter()
    {
        ui.ShowMessage("Message delivered. Long live the motherland!");
        yield return new WaitForSeconds(5);
        ui.HideMessage();
        levelManager.FinishLevel("Modern");
    }
}
