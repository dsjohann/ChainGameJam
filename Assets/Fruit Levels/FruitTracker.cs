using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTracker : MonoBehaviour
{
    public Dictionary<int, bool> fruitCollected = new Dictionary<int, bool>();
    public int fruitCount = 0;

    private void Awake()
    {
        for (int i = 25; i < 28; i++)
        {
            fruitCollected.Add(i, false);
        }
    }

    public void fruitFound(int levelIndex)
    {
        if (fruitCollected[levelIndex] == false)
        {
            fruitCollected[levelIndex] = true;
            fruitCount++;
        }
    }
}
