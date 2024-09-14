using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainObject : MonoBehaviour
{
    public GameObject driver;
    public GameObject chainPrefab;
    public GameObject chainedSprite;
    public float chainSnappiness;
    public float chainThreshold;
    public float adjustmentSnappiness;

    private Rigidbody2D RB;
    private GameObject chainClone;
    private bool wasChained;
    private Vector3 offset;
    private GameObject chainedSpriteClone;


    // Start is called before the first frame update
    void Start()
    {
        wasChained = false;
        offset = new Vector3 (0, 0, 0);
        //driver = null;
        RB = GetComponent<Rigidbody2D>();
        chainClone = Instantiate(chainPrefab);
        chainedSpriteClone = Instantiate(chainedSprite, transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (driver && !wasChained && driver.tag != "Player") {
            offset = transform.position - driver.transform.position;
            wasChained = true;
        }

        if (driver) {

            // chain pos
            chainClone.SetActive(true);
            chainClone.transform.position = (transform.position + driver.transform.position) / 2f;
            chainClone.GetComponent<SpriteRenderer>().size = new Vector2((transform.position - driver.transform.position).magnitude, 0.25f);
            chainClone.transform.rotation = Quaternion.FromToRotation(transform.right, (transform.position - driver.transform.position));

            if (driver.tag != "Player")
            {
                // positional code
                Vector3 differential = driver.transform.position + offset - transform.position;
                RB.velocity = differential * chainSnappiness;
                if (differential.magnitude > chainThreshold)
                {
                    offset -= differential * adjustmentSnappiness * Time.deltaTime;
                }

                // Turn gravity off
                GetComponent<TarodevController.ObjectController>().enabled = false;
                GetComponent<ObjectCarryable>().enabled = false;
            }

            chainedSpriteClone.SetActive(true);
        
        }
        else {
            chainClone.SetActive(false);
            // Turn gravity on
            RB.gravityScale = 1;
            wasChained = false;
            
            GetComponent<TarodevController.ObjectController>().enabled = true;
            GetComponent<ObjectCarryable>().enabled = true;
            chainedSpriteClone.SetActive(false);
        }
    }
}
