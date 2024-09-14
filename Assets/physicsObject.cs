using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class physicsObject : MonoBehaviour
{

    public LayerMask mask;

    public float speed;
    public float gravScale;
    public float groundExtent;

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
        GravityTime();

        AssignActualVelocities();
    }

    private void GravityTime()
    {
        if (Grounded())
        {
            plannedVelocity.y = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);

        }
        else
        {
            plannedVelocity.y -= gravScale;
        }
    }

    public bool Grounded()
    {
        RaycastHit2D groundHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, -transform.up, mask, 0, groundExtent);
        Debug.DrawRay(col.bounds.center, -transform.up * (col.bounds.extents.y + groundExtent), Color.red);
        if (groundHit.collider != null)
        {
            displacement.y = -(groundHit.distance - col.bounds.extents.y);
            return true;
        }
        return false;
    }

    private void AssignActualVelocities()
    {


        //Horizontal
        if (plannedVelocity.x > 0)
        {
            checkForWall(transform.right, plannedVelocity.x, 1);


            RaycastHit2D hit = Physics2D.Raycast(col.bounds.center, transform.right, col.bounds.extents.x + (plannedVelocity.x * Time.deltaTime), mask);
            Debug.DrawRay(col.bounds.center, transform.right * (col.bounds.extents.x + (plannedVelocity.x * Time.deltaTime)));
            if (hit.collider != null)
            {
                plannedVelocity.x = 0;
                displacement.x = hit.distance - col.bounds.extents.x;
            }
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
        }

        Debug.Log(plannedVelocity);
        rb.position += displacement;
        rb.velocity = plannedVelocity;

    }

    private bool checkForWall(Vector2 direction, float respectivePlannedVelocity, float sign)
    {
        RaycastHit2D hit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, direction, (sign * respectivePlannedVelocity * Time.deltaTime), mask, 0, groundExtent);
        Debug.DrawRay(col.bounds.center, direction * (col.bounds.extents.y + (respectivePlannedVelocity * Time.deltaTime)));
        if (hit.collider != null)
        {
            respectivePlannedVelocity = 0;
            displacement.y = sign(hit.distance - col.bounds.extents.y);
        }
    }
}
