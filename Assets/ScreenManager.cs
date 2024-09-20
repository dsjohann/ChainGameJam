using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public TMP_Text text;

    private SettingsManager settingsManager;

    public void SetNewText(string newTextKeyboard, string newTextController)
    {
        if (GameObject.FindGameObjectWithTag("Game Manager").GetComponent<SettingsManager>().currentMode == SettingsManager.controllerMode.Controller)
        {
            text.text = newTextController;
        }
        else
        {
            text.text = newTextKeyboard;
        }
    }
}
