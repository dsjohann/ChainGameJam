using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHolder : MonoBehaviour
{
    public bool invertedState;
    public float doorHoldingRange;
    public bool blockState = false;
    private LayerMask layers;

    // Start is called before the first frame update
    void Start()
    {
        layers = LayerMask.GetMask("Block", "Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 areaVector = new Vector3(doorHoldingRange, doorHoldingRange, 0);
        bool covered = Physics2D.OverlapArea(transform.position + areaVector, transform.position - areaVector, layers);
        transform.Find("SolidBlock").gameObject.SetActive(blockState && !covered);
    }
}
