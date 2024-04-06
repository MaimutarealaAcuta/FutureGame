using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, Interactable
{
    public string InteractMessage => "Pick up " + gameObject.name;

    [SerializeField] private bool isInteractable = true;
    [SerializeField] private Material highlightMaterial;
    public bool IsInteractable => isInteractable;


    private LevelManager levelManager;

    bool destroyed = false;

    [SerializeField]
    private string flag;

    public void Highlight()
    {
        // add outline material
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        List<Material> materialList = new List<Material>();
        meshRenderer.GetMaterials(materialList);
        materialList.Add(highlightMaterial);
        meshRenderer.SetMaterials(materialList);
    }

    public void Interact()
    {
        levelManager.ProgressObjective(flag);
        destroyed = true;
        Destroy(this.gameObject);
    }

    public void Unhighlight()
    {
        if (destroyed) return;
        // remove outline material
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        List<Material> materialList = new List<Material>();
        meshRenderer.GetMaterials(materialList);
        materialList.RemoveAt(materialList.Count - 1);
        meshRenderer.SetMaterials(materialList);
    }

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
}
