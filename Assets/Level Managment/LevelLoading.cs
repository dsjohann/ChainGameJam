using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    LevelLocker levelLocker;
    private void Start()
    {
        levelLocker = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<LevelLocker>();
    }

    public void NewScene()
    {
        levelLocker.levelUnlocked[SceneManager.GetActiveScene().buildIndex + 1] = true;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
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
