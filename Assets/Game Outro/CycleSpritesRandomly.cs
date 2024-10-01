using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class CycleSpritesRandomly : MonoBehaviour
{
    public Sprite[] spritesToCycle;
    public float cycleTime;

    private float timer = 0;
    private SpriteRenderer spriteRenderer;

    public Sprite emptySprite;

    private bool peopleHere = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        FruitTracker fruitTracker = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<FruitTracker>();
        if (fruitTracker.fruitCount == 3)
        {
            spriteRenderer.sprite = emptySprite;
            peopleHere = false;
        }
    }

    private void FixedUpdate()
    {
        if (peopleHere)
        {
            if (timer > cycleTime)
            {
                timer = 0;
                spriteRenderer.sprite = spritesToCycle[Random.Range(0, spritesToCycle.Length)];
            }
            else
            {
                timer++;
            }
        }
    }
}
