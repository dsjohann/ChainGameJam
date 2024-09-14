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
    private Vector3 lockPosition;
    private bool locked;

    // Start is called before the first frame update
    void Start()
    {
        locked = false;
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
        List<GameObject> chainLoopList = new List<GameObject>();
        chainLoopList.Add(gameObject);
        if (checkLooped(chainLoopList)) {
            if (!locked)
            {
                Debug.Log("LOCKED");
                GetComponent<TarodevController.ObjectController>().enabled = false;
                GetComponent<ObjectCarryable>().enabled = false;
                lockPosition = transform.position;
                RB.bodyType = RigidbodyType2D.Static;
                locked = true;
            }
            else {
                transform.position = lockPosition;
            }
        }

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
            wasChained = false;
            
            GetComponent<TarodevController.ObjectController>().enabled = true;
            GetComponent<ObjectCarryable>().enabled = true;
            chainedSpriteClone.SetActive(false);
        }
    }

    public bool checkLooped(List<GameObject> seen) {
        if (!driver || driver.tag == "Player")
        {
            return false;
        }
        else
        {
            if (seen.Contains(driver))
            {
                return true;
            }
            else {
                seen.Add(driver);
                return driver.GetComponent<ChainObject>().checkLooped(seen);
            }
        }
    }
}
