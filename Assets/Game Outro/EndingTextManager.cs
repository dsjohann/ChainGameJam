using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EndingTextManager : MonoBehaviour
{
    public TMP_Text TMP1;
    public TMP_Text TMP2;
    public TMP_Text TMP3;
    public SpriteRenderer fruitSprite;
    public Color textColor;

    public float fadeTime;
    public float bottomFadeDelay;

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
        float secondFade = (top - bottomFadeDelay) / bottom;
        fade = Mathf.Clamp(fade, 0, 1);
        secondFade = Mathf.Clamp(secondFade, 0, 1);

        TMP1.color = new Color(textColor.r, textColor.g, textColor.b, fade);
        TMP2.color = new Color(textColor.r, textColor.g, textColor.b, secondFade);
        TMP3.color = new Color(textColor.r, textColor.g, textColor.b, fade);
        fruitSprite.color = new Color(1, 1, 1, secondFade);
    }
}
