using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobSpriteSize : MonoBehaviour
{
    public float speed;
    public float amount;

    private Vector2 initialSize;

    private SpriteRenderer srRender;

    private void Start()
    {
        srRender = GetComponent<SpriteRenderer>();
        initialSize = srRender.size;
    }

    // Update is called once per frame
    void Update()
    {
        srRender.size = initialSize + new Vector2(Mathf.Cos(Time.time * speed) * amount, Mathf.Cos(Time.time * speed) * amount);
    }
}
