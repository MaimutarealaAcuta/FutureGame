using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PrehistoricLevelManager : LevelManager
{
    [SerializeField]
    private List<KeyValuePair<GameObject, int>> pickablesList;

    protected override void Start()
    {
        base.Start();
        SpawnPickables();
    }

    protected override string GetObjective()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.GetObjective());

        sb.AppendLine();
        sb.Append("BUILD A FIRE");
        sb.AppendLine();

        return sb.ToString();
    }

    // spawn pickables
    private void SpawnPickables()
    {
        foreach (KeyValuePair<GameObject, int> pickable in pickablesList)
        {
            for (int i = 0; i < pickable.value; i++)
            {
                GameObject instance = Instantiate(pickable.key, new Vector3(Random.Range(-100, 100), 500, Random.Range(-100, 100)), Quaternion.identity);
                // place instance on ground
                RaycastHit hit;
                if (Physics.Raycast(instance.transform.position, Vector3.down, out hit, 1000))
                {
                    instance.transform.position = hit.point;
                }                
            }
        }
    }

}
