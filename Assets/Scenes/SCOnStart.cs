using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCOnStart : MonoBehaviour
{
    private ScreenManager screenCall;

    public string KeyboardText;
    public string controllerText;

    private void Start()
    {
        screenCall = GetComponent<ScreenManager>();
        screenCall.SetNewText(KeyboardText, controllerText);
    }
}
