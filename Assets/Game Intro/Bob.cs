using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    Vector2 startingPos;
    public float speed;
    public float amount;

    private void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startingPos + new Vector2(0, Mathf.Cos(Time.time * speed) * amount);
    }
}
