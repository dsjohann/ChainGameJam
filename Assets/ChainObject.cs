using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainObject : MonoBehaviour
{
    public GameObject driver;
    public GameObject chainPrefab;
    public float chainSnappiness;
    public float chainThreshold;
    public float adjustmentSnappiness;

    private Rigidbody2D RB;
    private GameObject chainClone;
    private bool wasChained;
    private Vector3 offset;



    // Start is called before the first frame update
    void Start()
    {
        wasChained = false;
        offset = new Vector3 (0, 0, 0);
        //driver = null;
        RB = GetComponent<Rigidbody2D>();
        chainClone = Instantiate(chainPrefab);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (driver && !wasChained) {
            offset = transform.position - driver.transform.position;
            wasChained = true;
        }

        if (driver)
        {
            // chain pos
            chainClone.SetActive(true);
            chainClone.transform.position = (transform.position + driver.transform.position) / 2f;
            chainClone.GetComponent<SpriteRenderer>().size = new Vector2((transform.position - driver.transform.position).magnitude, 0.25f);
            chainClone.transform.rotation = Quaternion.FromToRotation(transform.right, (transform.position - driver.transform.position));

            Vector3 differential = driver.transform.position + offset - transform.position;
            RB.velocity = differential * chainSnappiness;
            if (differential.magnitude > chainThreshold) {
                offset -= differential * adjustmentSnappiness * Time.deltaTime;
            }
            
            // Turn gravity off
            RB.gravityScale = 0;
        }
        else {
            chainClone.SetActive(false);
            // Turn gravity on
            RB.gravityScale = 1;
            wasChained = false;
        }
    }
}
