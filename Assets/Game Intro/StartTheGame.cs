using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheGame : MonoBehaviour
{
    //Dalton ik this si so fucking bad. It would be better if I was more sober. Sorry <3

    public GameObject chain1;
    public GameObject chain2;
    public GameObject player;
    public GameObject text;

    public float startShakePlayer;
    public float shakeSpeedMultPlayer;
    public float shakeAmountMultPlayer;

    public shakePos shakeScriptPlayer;

    public float startShakeCamera;
    public float shakeSpeedMultCamera;
    public float shakeAmountMultCamera;

    public shakePos shakeScriptCamera;

    public int startProcess;
    public int chainBreakTime;
    public int dropPlayer;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("lock") || startProcess > chainBreakTime)
        {
            startProcess++;
        }
        else if (startProcess > 0)
        {
            startProcess -= 15;
        }
        else
        {
            startProcess = 0;
        }

        if (startProcess == dropPlayer)
        {
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
        }

        if (startProcess == chainBreakTime )
        {
            BreakChains();
        }
    }

    private void Update()
    {
        float shakeTopP = (startProcess - startShakePlayer);
        float shakeBottomP = (chainBreakTime - startShakePlayer);
        float shakeP = shakeTopP / shakeBottomP;
        shakeP = Mathf.Clamp(shakeP, 0, 1);

        shakeScriptPlayer.speed = Mathf.Pow(shakeP * shakeSpeedMultPlayer, 2);
        shakeScriptPlayer.amount = shakeP * shakeAmountMultPlayer;

        if (startProcess >= chainBreakTime)
        {
            shakeScriptPlayer.gameObject.transform.position = player.transform.position;
            shakeScriptPlayer.enabled = false;
        }



        float shakeTopC = (startProcess - startShakeCamera);
        float shakeBottomC = (chainBreakTime - startShakeCamera);
        float shakeC = shakeTopC / shakeBottomC;
        shakeC = Mathf.Clamp(shakeC, 0, 1);

        shakeScriptCamera.speed = Mathf.Pow(shakeC * shakeSpeedMultCamera, 2);
        shakeScriptCamera.amount = shakeC * shakeAmountMultCamera;

        if (startProcess >= chainBreakTime && shakeScriptCamera.enabled)
        {
            shakeScriptCamera.enabled = false;
        }
    }

    void BreakChains()
    {
        chain1.GetComponent<StartChains>().retract = true;
        chain2.GetComponent<StartChains>().retract = true;
        text.SetActive(false);
    }
}
