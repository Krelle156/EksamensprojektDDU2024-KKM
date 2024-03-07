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
        if((desiredPosition-transform.position).magnitude > 2)
        {
            Debug.Log(DesiredRotation());
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
        else rb.velocity = Vector2.zero;
    }
}
