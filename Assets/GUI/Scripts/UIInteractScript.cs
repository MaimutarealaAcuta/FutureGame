using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInteractScript : MonoBehaviour
{
    [SerializeField] private TMP_Text interactText;
    
    public void ShowMessage(string Message)
    {
        interactText.text = Message;
        interactText.gameObject.SetActive(true);
    }

    public void HideMessage()
    {
        interactText.gameObject.SetActive(false);
    }
}
