using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

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

    protected void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        foreach (KeyValuePair<string, int> flag in flags)
        {
            playerInventory.SetFlag(flag.key, 0);
        }
        updateObjectiveHandler?.Invoke(GetObjective());
    }
}
