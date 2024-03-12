using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile : Unit
{
    protected float speed = 2;
    protected Vector3 desiredPosition;

    protected override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float DesiredRotation()
    {
        return Vector2.SignedAngle(transform.up,desiredPosition - transform.position);
    }

    public void SetWaypoint(Vector3 v)
    {
        desiredPosition = v;
    }

    public void removeWaypoint()
    {
        desiredPosition = transform.position;
    }
}
