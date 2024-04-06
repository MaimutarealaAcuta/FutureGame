using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class HubLevelManager : LevelManager
{
    private UIMessageScript messageScript;
    private PlayerInput playerInput;
    
    protected override string GetObjective()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.GetObjective());

        sb.AppendLine();
        sb.Append("SAVE THE FUTURE");
        sb.AppendLine();

        return sb.ToString();
    }

    protected override void Start()
    {
        base.Start();
        messageScript = FindObjectOfType<UIMessageScript>();
        playerInput = FindObjectOfType<PlayerInput>();

        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        playerInput.SetInputActive(false);
        messageScript.ShowMessage(null);
        yield return new WaitForSeconds(5);
        messageScript.HideMessage();
        yield return new WaitForSeconds(1);

        StringBuilder sb = new StringBuilder();
        sb.Append("WELCOME TO THE HUB");
        sb.AppendLine();
        sb.AppendLine();
        sb.Append("WASD - movement, Shift - sprint, Space - Jump");
        sb.AppendLine();
        sb.Append("E - interact");
        sb.AppendLine();
        sb.Append("ESC - pause");
        sb.AppendLine();
        sb.Append("TAB - view objectives");
        messageScript.ShowMessage(sb.ToString());
        
        yield return new WaitForSeconds(5);
        messageScript.HideMessage();

        playerInput.SetInputActive(true);
    }
}
