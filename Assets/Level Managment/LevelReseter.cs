using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReseter : MonoBehaviour
{
    private GameObject player;

    void Start() {
        player = GameObject.Find("Player Controller");
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Reset") || player.transform.position.y < -6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}
