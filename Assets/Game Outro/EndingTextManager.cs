using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EndingTextManager : MonoBehaviour
{
    public TMP_Text TMP;

    public float fadeTime;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }
    public void Update()
    {
        float top = (Time.time - startTime);
        float bottom = (fadeTime);
        float fade = top / bottom;
        fade = Mathf.Clamp(fade, 0, 1);

        TMP.color = new Color(0, 0, 0, fade);
    }
}
