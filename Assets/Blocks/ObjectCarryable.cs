using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ObjectCarryable : MonoBehaviour
{
    public LayerMask CarrierMask;
    public float velocityMod;

    private Rigidbody2D _rb;
    private BoxCollider2D _col;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D groundCollision = Physics2D.BoxCast(_col.bounds.center, _col.size, 0, Vector2.down, .01f, CarrierMask);
        if (groundCollision.collider != null)
        {
            Vector2 carrierVel = groundCollision.collider.transform.GetComponent<Rigidbody2D>().velocity;
            Debug.Log("On top of " + groundCollision.collider.gameObject + " which has a vel of " + carrierVel);
            _rb.velocity = new Vector2(carrierVel.x, _rb.velocity.y);
        }
    }
}
