using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DifEndText : MonoBehaviour
{
    public GameObject defaultText;
    public GameObject secretText;

    // Start is called before the first frame update
    void Start()
    {
        FruitTracker fruitTracker = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<FruitTracker>();
        if (fruitTracker.fruitCount == 3)
        {
            defaultText.SetActive(false);
            secretText.SetActive(true);
        }
    }
}
