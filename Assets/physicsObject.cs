using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsObject : MonoBehaviour
{
    {
    public LayerMask mask;

    public float speed;

    private Vector2 plannedVelocity;
    private Vector2 displacement;

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

        GravityTime();

        AssignActualVelocities();
    }

    private void GravityTime()
    {
        if (Grounded())
        {

        }
    }

    private bool Grounded()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(col.bounds.center, -transform.up, col.bounds.extents.y + .01f, mask);
        if (groundHit.collider != null)
        {
            return true;
        }
        return false;
    }

    private void AssignActualVelocities()
    {
        //Horizontal
        if (plannedVelocity.x > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(col.bounds.center, transform.right, col.bounds.extents.x + (plannedVelocity.x * Time.deltaTime), mask);
            Debug.DrawRay(col.bounds.center, transform.right * (col.bounds.extents.x + (plannedVelocity.x * Time.deltaTime)));
            if (hit.collider != null)
            {
                plannedVelocity.x = 0;
                displacement.x = hit.distance - col.bounds.extents.x;
            }
            Debug.Log(hit.collider);
        }
        else if (plannedVelocity.x < 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(col.bounds.center, -transform.right, col.bounds.extents.x + (-plannedVelocity.x * Time.deltaTime), mask);
            Debug.DrawRay(col.bounds.center, -transform.right * (col.bounds.extents.x + (-plannedVelocity.x * Time.deltaTime)));
            if (hit.collider != null)
            {
                plannedVelocity.x = 0;
                displacement.x = -(hit.distance - col.bounds.extents.x);
            }
            Debug.Log(hit.collider);
        }

        //Vertical
        if (plannedVelocity.y > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(col.bounds.center, transform.up, col.bounds.extents.y + (plannedVelocity.y * Time.deltaTime), mask);
            Debug.DrawRay(col.bounds.center, transform.up * (col.bounds.extents.y + (plannedVelocity.y * Time.deltaTime)));
            if (hit.collider != null)
            {
                plannedVelocity.y = 0;
                displacement.y = hit.distance - col.bounds.extents.y;
            }
            Debug.Log(hit.collider);
        }
        else if (plannedVelocity.y < 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(col.bounds.center, -transform.up, col.bounds.extents.y + (-plannedVelocity.y * Time.deltaTime), mask);
            Debug.DrawRay(col.bounds.center, -transform.up * (col.bounds.extents.y + (-plannedVelocity.y * Time.deltaTime)));
            if (hit.collider != null)
            {
                plannedVelocity.y = 0;
                displacement.y = -(hit.distance - col.bounds.extents.y);
            }
            Debug.Log(hit.collider);
        }

        rb.position += displacement;
        rb.velocity = plannedVelocity;

    }
}
