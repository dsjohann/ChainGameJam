using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainObject : MonoBehaviour
{
    public GameObject driver;
    private Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        driver = null;

        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (driver)
        {
            RB.velocity = driver.GetComponent<Rigidbody2D>().velocity;
            // Turn gravity off
            RB.gravityScale = 0;
        }
        else {
            // Turn gravity on
            RB.gravityScale = 1;
        }
    }
}
