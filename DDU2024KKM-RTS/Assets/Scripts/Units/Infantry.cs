using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : Mobile
{
    gun test;
    
    protected override void Awake()
    {
        base.Awake();
        
        test = transform.GetComponentInChildren<AssaultRifle>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        transform.GetChild(0).GetComponent<AssaultRifle>().Fire();
        //Debug.Log(desiredPosition);
        //Desired rotation is currently set all the way back in mobile

        //if close to desired rotation turn slowly
        if (DesiredRotation() > 0) rb.angularVelocity = 1f;
        if (DesiredRotation() < 0) rb.angularVelocity = -1f;

        //if far from desired rotation turn fast
        if (DesiredRotation() > 2) rb.angularVelocity = 100;
        if (DesiredRotation() < -2) rb.angularVelocity = -100;

        if ((desiredPosition-transform.position).magnitude > 2)
        {
            
            /*
            if (Mathf.Abs(DesiredRotation()) < 30f)
            {
                rb.velocity = transform.up * speed;
            }
            else rb.velocity = Vector2.zero;
            */

            rb.velocity = movementVector * speed * (Mathf.Max(0.5f, 1 - (Vector2.Angle(transform.up, movementVector))/180)); //infantry moves slower if they aren't looking where they are going
            
        }
        else
        {
            rb.velocity = Vector2.zero;
            //rb.angularVelocity = 0f;
        }

    }
}
