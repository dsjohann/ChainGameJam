using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Data.Common;
using UnityEngine.Events;
using System.Threading;


public class Flicker : MonoBehaviour
{
    public UnityEvent callOn;
    public UnityEvent callOff;

    public float onFrequencyMin;
    public float onFrequencyMax;

    public float offFrequencyMin;
    public float offFrequencyMax;

    private bool lightOn;
    private float timer;
    public float timerSpeed;
    private float timeLimit;

    

    private void FixedUpdate()
    {
        if (lightOn)
        {
            if (timer > timeLimit)
            {
                callOff.Invoke();
                lightOn = false;
                timer = 0;
                timeLimit = Random.Range(offFrequencyMin, offFrequencyMax);
            }
            else
            {
                timer += timerSpeed;
            }
        }
        else
        {
            if (timer > timeLimit)
            {
                callOn.Invoke();
                lightOn = true;
                timer = 0;
                timeLimit = Random.Range(onFrequencyMin, onFrequencyMax);
            }
            else
            {
                timer += timerSpeed;
            }
        }
    }
}
