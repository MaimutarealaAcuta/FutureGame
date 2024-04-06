using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HologramTeleport : MonoBehaviour, Interactable
{
    [SerializeField] private string interactMessage;
    [SerializeField] private bool isInteractable;
    [SerializeField] private string sceneToLoad;
    
    public string InteractMessage => interactMessage;

    public bool IsInteractable => true;

    public void Highlight()
    {
        return;
    }

    public void Interact()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Unhighlight()
    {
        return;
    }

    // Update is called once per frame
    void Update()
    {
        // vertical sine move animation
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time) * 0.001f, transform.position.z);

    }
}
