using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCOnTrigger : MonoBehaviour
{
    private ScreenManager screenCall;

    public string KeyboardText;
    public string controllerText;

    public int layerToLookFor;

    private bool textSent = false;

    private void Start()
    {
        screenCall = GetComponent<ScreenManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (textSent == false && collision.gameObject.layer == layerToLookFor)
        {
            SendText();    
        }
    }

    private void SendText()
    {
        screenCall.SetNewText(KeyboardText, controllerText);
        textSent = true;
    }
}
