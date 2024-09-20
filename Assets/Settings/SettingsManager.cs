using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public enum controllerMode
    {
        Keyboard,
        Controller
    }

    public controllerMode currentMode;
}
