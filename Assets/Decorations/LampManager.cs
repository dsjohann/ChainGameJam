using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampManager : MonoBehaviour
{
    public Light2D lightScript;
    private SpriteRenderer spriteRenderer;

    public Sprite onSprite;
    public Sprite offSprite;

    // Start is called before the first frame update
    void Start()
    {
        lightScript = GetComponentInChildren<Light2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TurnOff()
    {
        spriteRenderer.sprite = offSprite;
        lightScript.enabled = false;
    }

    public void TurnOn()
    {
        spriteRenderer.sprite = onSprite;
        lightScript.enabled = true;
    }
}
