using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class HubLevelManager : LevelManager
{
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
    }
}
