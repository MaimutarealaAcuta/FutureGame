using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusuroiScript : MonoBehaviour
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
            GetComponent<AudioSource>().Play();
            levelManager.ToggleEndGame(false);
        }
    }
}
