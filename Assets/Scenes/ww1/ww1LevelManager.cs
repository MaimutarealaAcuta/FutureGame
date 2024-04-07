using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ww1LevelManager : LevelManager
{
    [SerializeField]
    private GameObject mine;

    [SerializeField]
    private int mineNumber = 10;
    
    protected override string GetObjective()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.GetObjective());

        sb.AppendLine();
        sb.Append("Deliver the letter");
        sb.AppendLine();

        return sb.ToString();
    }
    
    protected override void Start()
    {
        base.Start();
        SpawnMines();
    }

    void Update()
    {
        
    }

    private void SpawnMines()
    {
        for (int i = 0; i < mineNumber; i++)
        {
            Vector3 position = new Vector3(Random.Range(0, 200), 500, Random.Range(100, 230));
            GameObject instance = Instantiate(mine, position, Quaternion.identity);
            instance.name = mine.name;

            RaycastHit hit;
            if (Physics.Raycast(instance.transform.position, Vector3.down, out hit, 1000))
            {
                instance.transform.position = hit.point;
            }
            
            instance.transform.rotation = Quaternion.Euler(-90, Random.Range(0, 360), 0);
        }
    }
}
