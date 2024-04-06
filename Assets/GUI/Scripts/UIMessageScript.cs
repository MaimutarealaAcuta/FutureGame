using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMessageScript : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;

    public void ShowMessage(string Message)
    {
        if(Message != null) messageText.text = Message;
        StartCoroutine(FadeInMessage());
    }

    public void HideMessage()
    {
        StartCoroutine(FadeOutMessage());
    }

    IEnumerator FadeInMessage()
    {
        messageText.gameObject.SetActive(true);
        messageText.alpha = 0;
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            messageText.alpha = i;
            yield return null;
        }
        messageText.gameObject.SetActive(true);
    }

    IEnumerator FadeOutMessage()
    {
        messageText.alpha = 1;
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            messageText.alpha = i;
            yield return null;
        }
        messageText.gameObject.SetActive(false);
    }
}
