using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCode : MonoBehaviour
{
    public List<GameObject> connectedBlocks;
    public float activeArea;
    private LayerMask layers;
    private bool lastState;

    // Start is called before the first frame update
    void Start()
    {
        lastState = false;
        layers = LayerMask.GetMask("Block", "Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 areaVector = new Vector3(activeArea, activeArea, 0);

        bool currentState = Physics2D.OverlapArea(transform.position + areaVector, transform.position - areaVector, layers);
        if ( currentState != lastState)
        {
            foreach (GameObject i in connectedBlocks) {
                i.transform.Find("SolidBlock").gameObject.SetActive(!currentState);
            }
            lastState = currentState;
        }
    }
}
