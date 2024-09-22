using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCChangeSpriteOnPress : MonoBehaviour
{
    public string inputButton;

    public Sprite screenOn;
    public Sprite screenOff;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void Update()
    {
        if (Input.GetButton(inputButton))
        {
            spriteRenderer.sprite = screenOff;
        } 
        else
        {
            spriteRenderer.sprite = screenOn;
        }
    }
}
