using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    LevelUnlock levelUnlock;
    private void Start()
    {
        levelUnlock = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<LevelUnlock>();
    }

    public void NewScene()
    {
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
