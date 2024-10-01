using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSecretLevel : MonoBehaviour
{
    LevelLocker levelLocker;
    public int secretLevelIndex;

    private void Start()
    {
        levelLocker = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<LevelLocker>();
    }

    public void NewScene()
    {
        levelLocker.levelUnlocked[secretLevelIndex] = true;
        SceneManager.LoadSceneAsync(secretLevelIndex, LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.tag == "Player")
            {
                NewScene();
            }
        }
    }
}
