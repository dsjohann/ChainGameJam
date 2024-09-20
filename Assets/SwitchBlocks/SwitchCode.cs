using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCode : MonoBehaviour
{
    public List<GameObject> connectedBlocks;
    public float activeArea;
    private LayerMask layers;
    private int lastState;

    // Start is called before the first frame update
    void Start()
    {
        lastState = -1;
        layers = LayerMask.GetMask("Block", "Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 areaVector = new Vector3(activeArea, activeArea, 0);

        bool currentState = Physics2D.OverlapArea(transform.position + areaVector, transform.position - areaVector, layers);
        
        foreach (GameObject i in connectedBlocks) {
            bool iSetState = currentState ^ i.GetComponent<StateHolder>().invertedState;
            if (currentState || lastState == -1 || lastState == 1)
            {
                i.GetComponent<StateHolder>().blockState = iSetState;
            }
        }

        if (currentState)
        {
            lastState = 1;
        }
        else {
            lastState = 0;
        }
    }
}
