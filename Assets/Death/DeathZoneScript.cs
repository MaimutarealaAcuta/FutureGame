using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour
{
    private LevelManager levelManager;
    
    void Start()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelManager.ToggleEndGame();
        }
    }
}
