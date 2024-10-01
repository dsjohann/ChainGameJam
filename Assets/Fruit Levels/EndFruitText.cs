using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndFruitText : MonoBehaviour
{

    void Start()
    {
        FruitTracker fruitTacker = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<FruitTracker>();
        TMP_Text text = GetComponent<TMP_Text>();
        text.text = new string(fruitTacker.fruitCount + "/3");
    }
}
