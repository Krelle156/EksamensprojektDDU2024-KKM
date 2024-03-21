using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonk : Mobile
{
    protected Infantry hullGunner, driver, commander, loader;
    protected Infantry[] crewList;
    protected int crewCount;

    protected Mobile[] turrets;
    protected Infantry turretGunner;
    protected Vector3 rightTrack, leftTrack;
    protected Vector3 rightTrackForce=Vector2.zero, leftTrackForce= Vector2.zero;

    protected override void Awake()
    {
        base.Awake();
        crewList = new Infantry[3]; //this vehicle can hold three people
        Debug.Log(crewList.Length);
        
    }
    void Start()
    {
        
    }

    protected override void Update()
    {
        //base.Update(); currently doesn't have a rigidbody or awake function as such this doesn't work as intended.

    }

    protected void FixedUpdate()
    {
        rightTrack = transform.right * 2f;
        leftTrack = transform.right * -2f;
        if (Input.GetKey("a")) TurnLeft();
        if (Input.GetKey("d")) TurnRight();
    }

    public override void TurnLeft()
    {
        rb.AddForceAtPosition(transform.up * 200000 * Time.fixedDeltaTime, transform.position + rightTrack);

    }

    public override void TurnRight()
    {
        rb.AddForceAtPosition(transform.up * 200000 * Time.fixedDeltaTime, transform.position + leftTrack);
    }
    protected void addCrew(Infantry newGuy)
    {
        if(!(crewCount>=crewList.Length))
        {
            crewList[crewCount] = newGuy;
            if(crewCount < 4)
            {
                switch (crewCount) //for dynamically giving roles to those entering the vehicle based on crew count
                {
                    //this needs similar function for unassigning roles
                    case 0:
                        driver = newGuy;
                        break;

                        case 1:
                        hullGunner = newGuy;
                        commander = newGuy;
                        loader = newGuy;
                        break;

                        case 2:
                        loader = newGuy;
                        break;

                        case 3:
                        commander = newGuy;
                        break;

                }
                
            }
        }
    }
}
