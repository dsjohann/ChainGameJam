using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyButtonToMenu : MonoBehaviour
{
    EndingTextManager endingTextManager;

    private void Start()
    {
        endingTextManager = GetComponent<EndingTextManager>();
    }

    private void Update()
    {
        if (endingTextManager.secondFade >= 1)
        {
            if (Input.GetButton("select") || Input.GetButton("Menu"))
            {
                SceneManager.LoadScene(24, LoadSceneMode.Single);
            }
        }
    }

    
}
