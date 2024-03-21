using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonk : Mobile
{
    protected float enginePower, maxEnginePower = 200000;
    protected float engineThrottle = 0, poweredTracks=0;

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
        
    }
    void Start()
    {
        
    }

    protected override void Update()
    {
        base.Update();
        rightTrackForce = Vector2.zero; leftTrackForce = Vector2.zero;
        engineThrottle = -1;
        poweredTracks = 0;

        if (Input.GetKey("a")) TurnLeft();//only for temporary playerControl
        if (Input.GetKey("d")) TurnRight();

        
        if((desiredPosition - transform.position).magnitude > 2 && !isPlayerControlled) //if not controlled by player and not at position then do movement
        {
            //if close to desired rotation turn slowly
            if (DesiredRotation() > 0) TurnLeft();
            if (DesiredRotation() < 0) TurnRight();

            //if far from desired rotation turn fast
            if (DesiredRotation() > 2) TurnLeft();
            if (DesiredRotation() < -2) TurnRight();

            if (Mathf.Abs(DesiredRotation()) < 2) //if pointing towards the target position, move.
            {
                TurnLeft();
                TurnRight();
            }
        }
    }

    protected void FixedUpdate()
    {
        rightTrack = transform.right * 2f;
        leftTrack = transform.right * -2f;

            rb.AddForceAtPosition((rightTrackForce) * Time.fixedDeltaTime, transform.position + rightTrack);
            rb.AddForceAtPosition((leftTrackForce) * Time.fixedDeltaTime, transform.position + leftTrack);
        

        enginePower = Mathf.Min(Mathf.Max(0,enginePower+engineThrottle*10000), maxEnginePower);
    }

    public override void TurnLeft()
    {
        poweredTracks += 1;
        rightTrackForce = 200000*transform.up;
        engineThrottle = 1;

    }

    public override void TurnRight()
    {
        poweredTracks += 1;
        leftTrackForce = 200000 * transform.up;
        engineThrottle = 1;
    }

    public override float DesiredRotation() //the difference between where the unit is looking and where it "wants" to be looking
    {
        if((desiredPosition - transform.position).magnitude > 2) return Vector2.SignedAngle(transform.up, desiredPosition - transform.position);

        if (target == null) return Vector2.SignedAngle(transform.up, desiredPosition - transform.position);
        if (isInRange()) return Vector2.SignedAngle(transform.up, target.position - transform.position);
        return Vector2.SignedAngle(transform.up, desiredPosition - transform.position);
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
