using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOpacityDueToTargetPos : MonoBehaviour
{
    public Transform targetTs;
    public float startXPos;
    public float endXPos;

    private SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float top = (targetTs.position.x - startXPos);
        float bottom = (endXPos - startXPos);
        float fade = top / bottom;
        fade = Mathf.Clamp(fade, 0, 1);

        renderer.color = new Color(1, 1, 1, fade);
    }

}
