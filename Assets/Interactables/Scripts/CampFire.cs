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

    public bool IsInteractable => isInteractable;

    private LevelManager levelManager;

    public void Highlight()
    {
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
        LightFire();
        interactMessage = "";
        isInteractable = false;        
    }

    public void Unhighlight()
    {
        return;
    }
    
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void LightFire()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = materialList[1];
    }

    
}
