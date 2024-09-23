using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakePos : MonoBehaviour
{
    Vector3 startingPos;
    public float speed;
    public float amount;

    private void Start()
    {
        startingPos = transform.position;
    }

    private void Update()
    {
        transform.position = startingPos + new Vector3(Mathf.Sin(Time.time * speed) * amount, Mathf.Cos(Time.time * speed) * amount , 0);
    }
}
