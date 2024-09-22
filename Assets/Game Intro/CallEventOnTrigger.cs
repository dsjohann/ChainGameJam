using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallEventOnTrigger : MonoBehaviour
{
    private bool eventSent;
    public UnityEvent startLightEvent;

    public int layerToLookFor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (eventSent == false && collision.gameObject.layer == layerToLookFor)
        {
            eventSent = true;
            startLightEvent.Invoke();
        }
    }
}
