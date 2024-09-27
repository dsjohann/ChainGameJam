using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCAfterBlink : MonoBehaviour
{
    private ScreenManager screenCall;

    public string KeyboardText;
    public string controllerText;

    public float blinkOffTime;
    public float blinkOnTime;
    private float timer;

    private bool screenOn;
    private SpriteRenderer srRenderer;

    public Sprite onScreen;
    public Sprite offScreen;

    private void Start()
    {
        srRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        timer++;
    }

    private void Update()
    {
        if (timer >= blinkOnTime)
        {
            srRenderer.sprite = onScreen;
            screenOn = true;
            screenCall = GetComponent<ScreenManager>();
            screenCall.SetNewText(KeyboardText, controllerText);
        }
        else if (blinkOnTime > timer && timer >= blinkOffTime)
        {
            screenOn = false;
            srRenderer.sprite = offScreen;
            screenCall = GetComponent<ScreenManager>();
            screenCall.SetNewText(" ", " ");
        }
    }
}
