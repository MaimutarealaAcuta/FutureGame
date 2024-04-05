using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    string InteractMessage
    {
        get;
    }
    bool IsInteractable
    {
        get;
    }

    public void Interact();
    public void Highlight();
    public void Unhighlight();

}
