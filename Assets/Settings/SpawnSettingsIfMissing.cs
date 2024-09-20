using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSettingsIfMissing : MonoBehaviour
{
    public GameObject gameManager;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Game Manager") == null)
        {
            Instantiate(gameManager, null);
        }
    }
}
