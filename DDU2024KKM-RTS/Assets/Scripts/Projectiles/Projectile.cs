using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected float maxFlightDistance = 20;
    protected float flightDistance = 10;

    protected float speed = 10;

    protected Rigidbody2D r;

    [SerializeField] protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    
    void Update()
    {
        if (flightDistance > 0)
        {
            flightDistance -= rb.velocity.magnitude * Time.deltaTime;
        }
        //else if (flightDistance <= 0) GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        else if (flightDistance <= 0) GroundImpact();
    }

    public virtual void Launch(float dist, Vector2 direction)
    {
        maxFlightDistance = dist;
        transform.up = direction;
    }

    protected virtual void GroundImpact()
    {
        CameraController.boomTempTest.spawn(transform.position, 0.25f, 3f);
        Destroy(gameObject);
    }

    protected virtual void Impact()
    {
        CameraController.boomTempTest.spawn(transform.position, 0.25f, 1f);
        Destroy(gameObject);
    }
}
