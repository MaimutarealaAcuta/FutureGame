using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour, Interactable
{
    private string interactMessage = "Make fire";
    
    public string InteractMessage => interactMessage;

    [SerializeField]
    private bool isInteractable = false;

    [SerializeField]
    private Material[] materialList = new Material[2]; // 0 - unlit, 1 - lit

    [SerializeField]
    private GameObject fire;
    
    public bool IsInteractable => isInteractable;

    private LevelManager levelManager;

    private UIMessageScript ui;
    private bool highlightable = true;


    public void Highlight()
    {
        if(!highlightable) return;

        if(!levelManager.CheckObjective("stones"))
        {
            interactMessage = "Collect stones";
            return;
        }
        if (!levelManager.CheckObjective("twigs"))
        {
            interactMessage = "Collect twigs";
            return;
        }
        if (!levelManager.CheckObjective("flint"))
        {
            interactMessage = "Collect flint";
            return;
        }

        isInteractable = true;
        interactMessage = "Make fire";
    }

    public void Interact()
    {
        if (!isInteractable) return;
        StartCoroutine(LightFire());
        interactMessage = "";
        isInteractable = false;
        highlightable = false;
    }

    public void Unhighlight()
    {
        return;
    }
    
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        ui = FindObjectOfType<UIMessageScript>();
        fire.SetActive(false);
    }

    IEnumerator LightFire()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = materialList[1];
        fire.SetActive(true);
        ui.ShowMessage("Prometheus! You have brought fire to humanity!");
        yield return new WaitForSeconds(5);
        ui.HideMessage();
        levelManager.FinishLevel("Prehistoric");
    }

    
}
