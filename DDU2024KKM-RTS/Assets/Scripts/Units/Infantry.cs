using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : Mobile
{
    protected override void Awake()
    {
        base.Awake();
        desiredPosition = transform.position + new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if((desiredPosition-transform.position).magnitude > 1)
        {
            Debug.Log(desiredRotation());
            //Desired rotation is currently set all the way back in mobile

            //if close to desired rotation turn slowly
            if (desiredRotation() > 0) rb.angularVelocity = 1f;
            if (desiredRotation() < 0) rb.angularVelocity = -1f;

            //if far from desired rotation turn fast
            if (desiredRotation() > 2) rb.angularVelocity = 10;
            if (desiredRotation() < -2) rb.angularVelocity = -10;

            if (Mathf.Abs(desiredRotation()) < 0.5f)
            {
                rb.velocity = transform.up * speed;
            }
            else rb.velocity = Vector2.zero;
        }
    }
}
