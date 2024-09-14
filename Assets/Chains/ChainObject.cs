using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainObject : MonoBehaviour
{
    public GameObject driver;
    private Rigidbody2D RB;
    public GameObject chainPrefab;
    private GameObject chainClone;

    // Start is called before the first frame update
    void Start()
    {
        //driver = null;
        RB = GetComponent<Rigidbody2D>();
        chainClone = Instantiate(chainPrefab);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (driver)
        {
            chainClone.SetActive(true);
            chainClone.transform.position = (transform.position + driver.transform.position) / 2f;
            chainClone.GetComponent<SpriteRenderer>().size = new Vector2((transform.position - driver.transform.position).magnitude, 0.25f);
            chainClone.transform.rotation = Quaternion.FromToRotation(transform.right, (transform.position - driver.transform.position));
            RB.velocity = driver.GetComponent<Rigidbody2D>().velocity;
            // Turn gravity off
            RB.gravityScale = 0;
        }
        else {
            chainClone.SetActive(false);
            // Turn gravity on
            RB.gravityScale = 1;
        }
    }
}
