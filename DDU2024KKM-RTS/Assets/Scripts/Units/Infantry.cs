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
       
        if ((desiredPosition-transform.position).magnitude > 2)
        {
            //Debug.Log(desiredPosition);
            //Desired rotation is currently set all the way back in mobile

            //if close to desired rotation turn slowly
            if (DesiredRotation() > 0) rb.angularVelocity = 1f;
            if (DesiredRotation() < 0) rb.angularVelocity = -1f;

            //if far from desired rotation turn fast
            if (DesiredRotation() > 2) rb.angularVelocity = 100;
            if (DesiredRotation() < -2) rb.angularVelocity = -100;

            if (Mathf.Abs(DesiredRotation()) < 30f)
            {
                rb.velocity = transform.up * speed;
            }
            else rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

    }
}
