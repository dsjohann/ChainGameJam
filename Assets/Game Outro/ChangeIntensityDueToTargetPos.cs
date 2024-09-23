using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChangeIntensityDueToTargetPos : MonoBehaviour
{
    public Transform targetTs;
    public float startXPos;
    public float midXPos;
    public float endXPos;

    public float midLightMult;

    private Light2D lightScript;

    private void Start()
    {
        lightScript = GetComponent<Light2D>();
    }

    private void Update()
    {
        if (targetTs.position.x < midXPos)
        {
            float top = (targetTs.position.x - startXPos);
            float bottom = (midXPos - startXPos);
            float fade = top / bottom;
            fade = Mathf.Clamp(fade, 0, 1);

            lightScript.intensity = 1-fade*midLightMult;
        }
        else
        {
            float top = (targetTs.position.x - midXPos);
            float bottom = (endXPos - midXPos);
            float fade = top / bottom;
            fade = Mathf.Clamp(fade, midLightMult, 1);

            lightScript.intensity = fade;
        }
    }
}
