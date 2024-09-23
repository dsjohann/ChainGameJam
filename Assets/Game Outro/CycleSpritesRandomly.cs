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

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
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
