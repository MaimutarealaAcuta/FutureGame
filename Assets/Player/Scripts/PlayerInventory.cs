using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<string, int> flags;

    private void Awake()
    {
        flags = new Dictionary<string, int>();
    }

    public void SetFlag(string flag, int val)
    {
        if (!flags.ContainsKey(flag))
        {
            flags.Add(flag, val);
        }
        else
        {
            flags[flag] = val;
        }
    }

    public void IncrementFlag(string flag)
    {
        if (!flags.ContainsKey(flag)) return;

        flags[flag]++;
    }

    public int GetFlag(string flag)
    {
        if (!flags.ContainsKey(flag))
        {
            return -1;
        }
        else
        {
            return flags[flag];
        }
    }
}
