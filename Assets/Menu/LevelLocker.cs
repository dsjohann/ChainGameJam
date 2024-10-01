using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLocker : MonoBehaviour
{
    public Dictionary<int, bool> levelUnlocked = new Dictionary<int, bool>();

    private void Awake()
    {
        levelUnlocked.Add(0, true);
        for (int i = 1; i < 28; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex >= i)
            {
                levelUnlocked.Add(i, true);
            }
            else
            {
                levelUnlocked.Add(i, false);
            }

        }
    }
}
