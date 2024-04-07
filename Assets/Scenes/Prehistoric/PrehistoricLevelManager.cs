using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PrehistoricLevelManager : LevelManager
{
    [SerializeField]
    private List<KeyValuePair<GameObject, int>> pickablesList;

    [SerializeField]
    private Transform spawnCenter;

    [SerializeField]
    private float spawnRadius = 5f;

    protected override void Start()
    {
        base.Start();
        SpawnPickables(spawnCenter, spawnRadius);
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
    private void SpawnPickables(Transform center, float radius)
    {
        foreach (KeyValuePair<GameObject, int> pickable in pickablesList)
        {
            for (int i = 0; i < pickable.value; i++)
            {
                float dist = Random.Range(0, radius);
                float angle = Random.Range(0, 2 * Mathf.PI);

                Vector3 pos = spawnCenter.position + new Vector3(Mathf.Cos(angle) * dist, 500, Mathf.Sin(angle) * dist);
                
                GameObject instance = Instantiate(pickable.key, pos, Quaternion.identity);
                instance.name = pickable.key.name;
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
