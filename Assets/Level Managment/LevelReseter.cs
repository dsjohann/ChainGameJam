using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReseter : MonoBehaviour
{
    private GameObject player;
    public float deathZone;

    void Start() {
        player = GameObject.Find("Player Controller");
    }
    
    private void Update()
    {
        if (Input.GetButton("Menu"))
        {
            SceneManager.LoadScene(24, LoadSceneMode.Single);
        }

        if (Input.GetButton("Reset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }

    private void FixedUpdate()
    {
        if (player.transform.position.y < deathZone)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}
