using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonk : Mobile
{
    protected float smokeCoolDown, smokeCoolMax = 2f;

    protected float enginePower, maxEnginePower = 800000;
    protected float engineThrottle = 0, poweredTracks=0;

    protected Infantry hullGunner, driver, commander, loader;
    protected Infantry[] crewList;
    protected int crewCount;

    protected Mobile[] turrets;
    protected Infantry turretGunner;
    protected Vector3 rightTrack, leftTrack;
    protected Vector3 rightTrackForce=Vector2.zero, leftTrackForce= Vector2.zero;
    

    [SerializeField]Weapon weapon; //Tanks should also have hulls with no hull mounted weapons, this is not a desired field

    AudioSource audi;

    protected override void Awake()
    {
        base.Awake();
        crewList = new Infantry[3]; //this vehicle can hold three people
        audi = GetComponent<AudioSource>();
        //target = Player.targetTest;

        allegiance = 1; //for testing
        health = 100;
        armor = 10;

    }
    void Start()
    {
        
    }

    protected override void Update()
    {
        //reallyShouldn't be here, another band-aid fix
        if (Mathf.Abs(DesiredRotation()) < 1 && target != null)
        {
            if (target.TryGetComponent<Unit>(out Unit u))
            {
                if (u.allegiance != 0 && u.allegiance != allegiance) StandardAttack();
            }
        }

        base.Update();
        if (smokeCoolDown <= 0)
        {
            ParticleManager.SpawnSmoke(transform.position - transform.up * 2.1f - transform.right*1.2f+new Vector3(0,0,0.1f), 1+ (enginePower / maxEnginePower), 0.2f);
            smokeCoolDown = smokeCoolMax - (enginePower/maxEnginePower)*1.9f;
        }
        smokeCoolDown -= 1 * Time.deltaTime;

        rightTrackForce = Vector2.zero; leftTrackForce = Vector2.zero;
        engineThrottle = -1;
        poweredTracks = 0;

        if(!isPlayerControlled)
        {
            //if far from desired rotation turn fast
            if (DesiredRotation() > 2) TurnLeft();
            if (DesiredRotation() < -2) TurnRight();

            audi.pitch = (1.5f + (enginePower / maxEnginePower) * 1.5f);
            if ((desiredPosition - transform.position).magnitude > 5) //if not at position then move
            {
                if (Mathf.Abs(DesiredRotation()) < 2) //if pointing towards the target position, move.
                {
                    MoveForwards();
                }
            }
        }
        
    }

    protected void FixedUpdate()
    {
        rightTrack = transform.right * 2f;
        leftTrack = transform.right * -2f;

            rb.AddForceAtPosition((rightTrackForce) * Time.fixedDeltaTime, transform.position + rightTrack);
            rb.AddForceAtPosition((leftTrackForce) * Time.fixedDeltaTime, transform.position + leftTrack);
        

        enginePower = Mathf.Min(Mathf.Max(0,enginePower+engineThrottle*1000), maxEnginePower);
    }

    public override void TurnLeft()
    {
        poweredTracks += 1;
        rightTrackForce = enginePower*transform.up;
        engineThrottle = 1;

    }

    public override void TurnRight()
    {
        poweredTracks += 1;
        leftTrackForce = enginePower * transform.up;
        engineThrottle = 1;
    }

    protected override void MoveForwards()
    {
        base.MoveForwards();
        leftTrackForce = enginePower * transform.up;
        rightTrackForce = enginePower * transform.up;
        engineThrottle = 1;
    }
    public void MoveBackWards()
    {

    }

    public override float DesiredRotation() //the difference between where the unit is looking and where it "wants" to be looking
    {
        if((desiredPosition - transform.position).magnitude > 3) return Vector2.SignedAngle(transform.up, desiredPosition - transform.position);

        if (target == null) return Vector2.SignedAngle(transform.up, desiredPosition - transform.position);
        if (isInRange()) return Vector2.SignedAngle(transform.up, target.position - transform.position);
        return Vector2.SignedAngle(transform.up, desiredPosition - transform.position);
    }

    public void StandardAttack() //a function a bit like this is desired, but this is just copied from infantry, and it does not exist in the super-class
    {
        weapon.Fire(((Vector2)(transform.position-target.position)).magnitude);
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

    public override void CheckHealth()
    {
        if (health <= 0)
        {
            ParticleManager.SpawnExplosion(transform.position, 2, 30, 1);
        }
        base.CheckHealth();
    }
}
