using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGold : MonoBehaviour
{
    public Sprite goldSprite;

    // Start is called before the first frame update
    void Start()
    {
        FruitTracker fruitTracker = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<FruitTracker>();
        if (fruitTracker.fruitCount == 3)
        {
            GetComponent<SpriteRenderer>().sprite = goldSprite;
        }
    }
}
