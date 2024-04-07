using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MedievalLevelManager : LevelManager
{
    protected override void Start()
    {
        base.Start();
    }
    
    protected override string GetObjective()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.GetObjective());

        sb.AppendLine();
        sb.Append("POISON THE KING");
        sb.AppendLine();

        return sb.ToString();
    }

}
