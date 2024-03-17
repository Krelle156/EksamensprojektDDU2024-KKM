using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class Mobile : Unit
{
    protected float speed = 2;
    protected Vector3 desiredPosition;
    protected Vector2 movementVector, inertiaTime;


    protected override void Awake()
    {
        base.Awake();
        inertiaTime = Vector2.zero;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        transform.GetChild(0).GetComponent<AssaultRifle>().Fire();

        float tempSpeed = rb.velocity.magnitude;
        movementVector = Vector2.SmoothDamp(movementVector, DesiredMovementVector(), ref inertiaTime, tempSpeed);
    }

    public float DesiredRotation()
    {
        return Vector2.SignedAngle(transform.up,desiredPosition - transform.position);
    }

    public Vector2 DesiredMovementVector()
    {
        return (desiredPosition - transform.position).normalized;
    }

    public void SetWaypoint(Vector3 v)
    {
        desiredPosition = v;
    }

    public void removeWaypoint()
    {
        desiredPosition = transform.position;
    }

    public void turnRight()
    {

    }
    public void turnLeft()
    {

    }







}
