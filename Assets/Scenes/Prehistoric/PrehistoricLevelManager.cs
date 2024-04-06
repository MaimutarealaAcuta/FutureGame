using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PrehistoricLevelManager : LevelManager
{
    protected override string GetObjective()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.GetObjective());

        sb.AppendLine();
        sb.Append("BUILD A FIRE");
        sb.AppendLine();

        return sb.ToString();
    }

}
