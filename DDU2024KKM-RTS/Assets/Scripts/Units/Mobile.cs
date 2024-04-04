using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class Mobile : Unit
{
    protected float speed = 2;
    
    protected Vector2 movementVector, inertiaTime;

    protected bool isPlayerControlled = false;


    protected override void Awake()
    {
        base.Awake();
        inertiaTime = Vector2.zero;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //The following makes it so infantry can change the direction of movement instantly if they are standing still
        //otherwise the change is dependant on the speed of the unit

        //Must be moved to infantry once tanks are being implemented (perhaps before)

        float tempSpeed = Mathf.Min(rb.velocity.magnitude*0.1f,1);
        movementVector = Vector2.SmoothDamp(movementVector, DesiredMovementVector(), ref inertiaTime, tempSpeed);

   
    }

    public virtual float DesiredRotation() //the difference between where the unit is looking and where it "wants" to be looking
    {
        return Vector2.SignedAngle(transform.up,target.position - transform.position);
    }

    protected bool isInRange()
    {
        return true;
    }

    public Vector2 DesiredMovementVector() //Which direction the unit wants to go in
    {
        return (desiredPosition - transform.position).normalized;
    }

    

    public void TemoveWaypoint() //In case the unit doesn't need to change it's position
    {
        desiredPosition = transform.position;
    }

    public virtual void TurnRight() //(for the AI-script or player controlled units) turns the unit to the "right"
    {
        //Currently only implemented for the tank, probably should stay that way
    }
    public virtual void TurnLeft() //(for the AI-script or player controlled units) turns the unit to the "Left"
    {
        //Currently only implemented for the tank, probably should stay that way
    }

    protected virtual void MoveForwards()
    {
        //TO-DO - Make work!
    }

    public virtual void MoveBackwards()
    {
        //TO-DO - Make work!
    }







}
