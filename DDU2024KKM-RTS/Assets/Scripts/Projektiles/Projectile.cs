using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float maxFlightDistance = 20;
    protected float flightDistance = 10;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public virtual void Launch(float dist)
    {
        maxFlightDistance = dist;
    }
}
