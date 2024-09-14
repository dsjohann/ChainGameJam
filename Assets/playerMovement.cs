using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    public LayerMask mask;

    public float speed;

    private Vector2 plannedVelocity;

    private Collider2D col;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        plannedVelocity.x = Input.GetAxis("Horizontal") * speed;

        AssignActualVelocities();
    }

    private void AssignActualVelocities()
    {
        if (plannedVelocity.x > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(col.bounds.center, transform.right, col.bounds.extents.x + (plannedVelocity.x*Time.deltaTime), mask);
            Debug.DrawRay(col.bounds.center, transform.right * (col.bounds.extents.x + (plannedVelocity.x*Time.deltaTime)));
            if (hit.collider != null)
            {
                plannedVelocity.x = hit.distance * Time.deltaTime;
            }
            Debug.Log(hit.collider);
        }

        rb.velocity = plannedVelocity;
        
    }
}
