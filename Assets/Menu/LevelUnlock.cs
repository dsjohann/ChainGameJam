using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlock : MonoBehaviour
{
    public Dictionary<int, bool> levelUnlocked = new Dictionary<int, bool>();
    public float test;

    private void Start()
    {
        levelUnlocked.Add(0, true);
        for (int i = 1; i < 23; i++)
        {
            levelUnlocked.Add(i, false);
        }
    }
}
