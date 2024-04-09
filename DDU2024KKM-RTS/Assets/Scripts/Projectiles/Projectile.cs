using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected float maxFlightDistance = 20;
    protected float flightDistance = 10;

    protected float speed = 100;
    protected float allegiance;

    protected Rigidbody2D r;

    [SerializeField] protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
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
        flightDistance = dist;
        transform.up = direction;
    }

    protected virtual void GroundImpact()
    {
        ParticleManager.SpawnExplosion(transform.position, 0.25f, 6f);
        Destroy(gameObject);
    }

    protected virtual void Impact()
    {
        ParticleManager.SpawnExplosion(transform.position, 0.25f, 1f);
        Destroy(gameObject);
    }

    public void SetAllegiance(int i)
    {
        allegiance = i;
    }

}
