using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float maxFlightDistance = 20;
    protected float flightDistance = 10;

    [SerializeField] protected Rigidbody2D rb;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (flightDistance > -maxFlightDistance / 2)
        {
            
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

    }

    protected virtual void Impact()
    {

    }
}
