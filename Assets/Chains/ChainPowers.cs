using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainPowers : MonoBehaviour
{
    private bool chainStart;
    public float activeArea;
    private LayerMask layers;
    private GameObject chained;

    // Start is called before the first frame update
    void Start()
    {
        layers = LayerMask.GetMask("Block");
        chainStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject closest = nearby();
        if (Input.GetButtonDown("lock") && closest && !chainStart && !closest.GetComponent<ChainObject>().driver) {
            chainStart = true;
            chained = closest;
            chained.GetComponent<ChainObject>().driver = gameObject;
        } else if (closest && chainStart && closest != chained) {
            chainStart = false;
            chained.GetComponent<ChainObject>().driver = closest;
        }
    }

    private GameObject nearby() {
        Vector3 areaVector = new Vector3(activeArea, activeArea, 0);

        Collider2D collider = Physics2D.OverlapArea(transform.position + areaVector, transform.position - areaVector, layers);
        if (collider)
        {
            return collider.transform.gameObject;
        }
        else {
            return null;
        }
    }
}
