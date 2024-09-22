using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheGame : MonoBehaviour
{
    public GameObject chain1;
    public GameObject chain2;
    public GameObject player;
    public GameObject text;

    public float startShake;
    public float shakeSpeedMult;
    public float shakeAmountMult;

    public shakePos shakeScript;

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
        float shakeTop = (startProcess - startShake);
        float shakeBottom = (chainBreakTime - startShake);
        float shake = shakeTop / shakeBottom;
        shake = Mathf.Clamp(shake, 0, 1);

        shakeScript.speed = Mathf.Pow(shake * shakeSpeedMult, 2);
        shakeScript.amount = shake * shakeAmountMult;

        if (startProcess >= chainBreakTime)
        {
            shakeScript.gameObject.transform.position = player.transform.position;
            shakeScript.enabled = false;
        }
    }

    void BreakChains()
    {
        chain1.GetComponent<StartChains>().retract = true;
        chain2.GetComponent<StartChains>().retract = true;
        text.SetActive(false);
    }
}
