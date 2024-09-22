using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroFadeTitle : MonoBehaviour
{
    private SpriteRenderer titleSprite;

    public StartTheGame startScript;

    public int fadeStart;
    public int fadeEnd;

    private void Start()
    {
        titleSprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float fadeTop = (startScript.startProcess - fadeStart);
        float fadeBottom = (fadeEnd - fadeStart);
        float fade = fadeTop/fadeBottom;
        fade = Mathf.Clamp(fade, 0, 1);
        titleSprite.color = new Color(1, 1, 1, 1 - fade);
    }
}
