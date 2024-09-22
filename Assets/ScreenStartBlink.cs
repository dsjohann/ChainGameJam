using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenStartBlink : MonoBehaviour
{
    //Dalton, if you ever see this code, I'm sorry. Feel free to shoot me

    public Sprite onSprite;
    public Sprite offSprite;

    private SpriteRenderer renderer;

    private ScreenManager screenCall;

    public string KeyboardText;
    public string controllerText;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        screenCall = GetComponent<ScreenManager>();
    }

    public StartTheGame startScript;

    private int timer;
    private int timerLimit;

    public int blinkSpeed1;
    public int blinkTime1;
    public int blinkSpeed2;
    public int blinkTime2;
    public int blinkSpeed3;
    public int blinkTime3;
    public int blinkSpeed4;

    public int on1;
    public int off1;
    public int on2;

    void FixedUpdate()
    {
        if (startScript.startProcess == 0)
        {
            renderer.sprite = onSprite;
        }
        else if (startScript.startProcess > 0 && startScript.startProcess < startScript.chainBreakTime) 
        {
            if (startScript.startProcess < blinkTime1)
            {
                timerLimit = blinkSpeed1;
            }
            else if (startScript.startProcess < blinkTime2)
            {
                timerLimit = blinkSpeed2;
            }
            else if (startScript.startProcess < blinkTime3)
            {
                timerLimit = blinkSpeed3;
            } 
            else
            {
                timerLimit = blinkSpeed4;
            }

            if (timer >= timerLimit)
            {
                timer = 0;
                if (renderer.sprite == onSprite)
                {
                    renderer.sprite = offSprite;
                }
                else
                {
                    renderer.sprite = onSprite;
                }
            }
            else
            {
                timer++;
            }
        }
        else if (startScript.startProcess == startScript.chainBreakTime)
        {
            renderer.sprite = offSprite;
            startScript.text.SetActive(false);
        }
        else if (startScript.startProcess == on1)
        {
            renderer.sprite = onSprite;
        }
        else if (startScript.startProcess == off1)
        {
            renderer.sprite = offSprite;
        }
        else if (startScript.startProcess == on2)
        {
            startScript.text.SetActive(true);
            renderer.sprite = onSprite;
            SendText();
        }
    }

    private void SendText()
    {
        screenCall.SetNewText(KeyboardText, controllerText);
    }
}
