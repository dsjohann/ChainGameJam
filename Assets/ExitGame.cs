using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    private bool selectorOnTop;

    void Update()
    {
        
        if (Input.GetButtonDown("select") && selectorOnTop)
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        selectorOnTop = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        selectorOnTop = false;
    }
}
