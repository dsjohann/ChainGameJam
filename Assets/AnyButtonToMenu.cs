using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyButtonToMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButton("select") || Input.GetButton("Menu"))
        {
            SceneManager.LoadScene(24, LoadSceneMode.Single);
        }
    }
}
