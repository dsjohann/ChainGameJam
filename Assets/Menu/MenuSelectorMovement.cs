using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;

public class MenuSelectorMovement : MonoBehaviour
{
    public float gridDifX;
    public float gridDifY;

    private void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            transform.position += transform.right * gridDifX * Mathf.Sign(Input.GetAxisRaw("Horizontal"));
            if (transform.position.x < -10 || transform.position.x > 10)
            {
                transform.position -= transform.right * gridDifX * 7 * Mathf.Sign(Input.GetAxisRaw("Horizontal"));
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            transform.position += transform.up * gridDifY * Mathf.Sign(Input.GetAxisRaw("Vertical"));
            if (transform.position.y < -5 || transform.position.y > 5)
            {
                transform.position -= transform.up * gridDifY * 3 * Mathf.Sign(Input.GetAxisRaw("Vertical"));
            }
        }
    }
}
