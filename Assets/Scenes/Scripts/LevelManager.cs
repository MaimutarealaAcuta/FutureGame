using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class LevelManager: MonoBehaviour
{
    [Serializable]
    public struct KeyValuePair<K, V>
    {
        public K key;
        public V value;
    }

    public delegate void UpdateObjective(string Objective);
    public UpdateObjective updateObjectiveHandler;

    [SerializeField] protected List<KeyValuePair<string, int>> flags;
    protected PlayerInventory playerInventory;

    private UIGameOverScript uiGameOverScript;

    [SerializeField]
    protected GameManager gameManager;
    
    protected virtual string GetObjective()
    {
        StringBuilder sb = new StringBuilder();
        foreach (KeyValuePair<string, int> flag in flags)
        {
            sb.Append(string.Format("{0}: {1} / {2}\n", flag.key.ToUpperInvariant(), playerInventory.GetFlag(flag.key), flag.value));
            sb.AppendLine();
        }

        return sb.ToString();
    }

    public void ProgressObjective(string flag)
    {
        playerInventory.IncrementFlag(flag);
        updateObjectiveHandler?.Invoke(GetObjective());
    }

    public bool CheckObjective(string flag)
    {
        return playerInventory.GetFlag(flag) >= flags.Find(f => f.key == flag).value;
    }

    protected virtual void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        foreach (KeyValuePair<string, int> flag in flags)
        {
            playerInventory.SetFlag(flag.key, 0);
        }
        updateObjectiveHandler?.Invoke(GetObjective());

        uiGameOverScript = FindObjectOfType<UIGameOverScript>();
    }

    public void ToggleEndGame()
    {
        uiGameOverScript?.ToggleEndGame();
    }

    public void FinishLevel(string level)
    {
        switch(level)
        {
            case "Prehistoric":
                gameManager.solvedFire = true;
                break;
            case "Medieval":
                gameManager.solvedPoison = true;
                break;
            case "Modern":
                gameManager.solvedLetter = true;
                break;
        }

        SceneManager.LoadScene("SpaceShipHub");
    }
}
