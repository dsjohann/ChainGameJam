using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOnSpriteEndLevel : MonoBehaviour
{
    public Sprite newOnSprite;
    public Sprite newOffSprite;

    // Start is called before the first frame update
    void Start()
    {
        FruitTracker fruitTracker = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<FruitTracker>();
        if (fruitTracker.fruitCount == 3)
        {
            MenuLevelIcon menuScript = GetComponent<MenuLevelIcon>();
            menuScript.onSprite = newOnSprite;
            menuScript.offSprite = newOffSprite;
        }
    }
}
