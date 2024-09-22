using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightsComeOn : MonoBehaviour
{
    private bool lightsCalled;

    private int timer;
    public int on1;
    public int off1;
    public int on2;

    private LampManager lampManager;

    private void Start()
    {
        lampManager = GetComponent<LampManager>();
    }

    public void startUpLight()
    {
        lightsCalled = true;
    }

    private void FixedUpdate()
    {
        if (lightsCalled) 
        {
            if (timer == on1)
            {
                lampManager.TurnOn();
            }
            else if(timer == off1)
            {
                lampManager.TurnOff(); 
            }
            if (timer == on2)
            {
                lampManager.TurnOn();
            }
            timer++;
        }
    }
}
