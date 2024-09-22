using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheGame : MonoBehaviour
{
    public GameObject chain1;
    public GameObject chain2;
    public GameObject player;
    public GameObject text;

    public int startProcess;
    public int chainBreakTime;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("lock") || startProcess > chainBreakTime)
        {
            startProcess++;
        }
        else if (startProcess > 0)
        {
            startProcess--;
        }

        if (chain1.GetComponent<StartChains>().doneRetracting == true)
        {
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
        }

        if (startProcess == chainBreakTime )
        {
            BreakChains();
        }
    }

    void BreakChains()
    {
        chain1.GetComponent<StartChains>().retract = true;
        chain2.GetComponent<StartChains>().retract = true;
        text.SetActive(false);
    }
}
