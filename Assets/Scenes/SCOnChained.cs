using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class SCOnChained : MonoBehaviour
{
    public enum CheckingFor
    {
        onPlayerToBlock,
        onBlockToBlock
    }

    public CheckingFor checkFor;

    private ScreenManager screenCall;

    public string KeyboardText;
    public string controllerText;

    public GameObject[] objectsToWatch;
    public LayerMask layer;

    private List<ChainObject> chainObjectScripts;

    private bool textSent = false;

    private void Start()
    {
        screenCall = GetComponent<ScreenManager>();

        chainObjectScripts  = new List<ChainObject>();
        for (int i = 0; i < objectsToWatch.Length; i++)
        {
            chainObjectScripts.Add(objectsToWatch[i].GetComponent<ChainObject>());
        }
    }

    private void Update()
    {
        if (textSent == false)
        {
            for (int i = 0; i < chainObjectScripts.Count; i++)
            {
                if (chainObjectScripts[i].driver)
                {
                    if (chainObjectScripts[i].driver.layer == 6 && checkFor == CheckingFor.onPlayerToBlock)
                    {
                        SendText();
                    } 
                    else if (chainObjectScripts[i].driver.layer == 7 && checkFor == CheckingFor.onBlockToBlock)
                    {
                        SendText();
                    }
                }
            }
        }
    }

    private void SendText()
    {
        screenCall.SetNewText(KeyboardText, controllerText);
        textSent = true;
    }
}
