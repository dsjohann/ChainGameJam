using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChains : MonoBehaviour
{
    public float chainSpeed;
    public bool retract = false;
    public bool doneRetracting = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localScale.x > .01f && retract)
        {
            transform.localScale = new Vector3(transform.localScale.x * chainSpeed, 1, 1);
        }
        else if (retract == true)
        {
            doneRetracting = true;
        }

    }
}
