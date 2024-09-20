using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheGame : MonoBehaviour
{
    public GameObject chain1;
    public GameObject chain2;
    public GameObject player;
    public GameObject text;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("lock"))
        {
            chain1.GetComponent<StartChains>().retract = true;
            chain2.GetComponent<StartChains>().retract = true;
            text.SetActive(false);
        }
        if (chain1.GetComponent<StartChains>().doneRetracting == true)
        {
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
        }
    }
}
