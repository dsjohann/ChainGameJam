using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLights : MonoBehaviour
{
    public StartTheGame startScript;

    public float flickerStart;
    public float flickerEnd;
    public float flickerMultiplier;

    private LampManager lampManager;
    private Flicker flickerScript;

    private void Start()
    {
        lampManager = GetComponent<LampManager>();
        flickerScript = GetComponent<Flicker>();
    }

    private void FixedUpdate()
    {
        float flickerTop = (startScript.startProcess - flickerStart);
        float flickerBottom = (flickerEnd - flickerStart);
        float flicker = flickerTop / flickerBottom;
        flicker = Mathf.Clamp(flicker, 0, 1);
        
        if (startScript.startProcess < flickerStart && lampManager.lightScript.enabled == false)
        {
            lampManager.TurnOn();
            flickerScript.enabled = false;
        }
        else if (startScript.startProcess > flickerEnd)
        {
            lampManager.TurnOff();
            flickerScript.enabled = false;
        }
        else
        {
            flickerScript.enabled = true;
            flickerScript.timerSpeed = flicker * flickerMultiplier;
        }
    }
}
