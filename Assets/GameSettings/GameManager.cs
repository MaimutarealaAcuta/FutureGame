using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/GameManager", order = 1)]
public class GameManager : ScriptableObject
{
    public float MasterVolume = 1.0f;

    public bool solvedFire = false;

    public bool solvedPoison = false;

    public bool solvedLetter = false;

    public bool passedTutorial = false;
}
