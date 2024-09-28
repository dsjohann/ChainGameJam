using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLocker : MonoBehaviour
{
    public Dictionary<int, bool> levelUnlocked = new Dictionary<int, bool>();

    private void Awake()
    {
        levelUnlocked.Add(0, true);
        for (int i = 1; i < 28; i++)
        {
            levelUnlocked.Add(i, false);
        }
    }
}
