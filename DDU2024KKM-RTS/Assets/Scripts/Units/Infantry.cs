using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : Mobile
{

    Weapon weapon;
    Player bob;
    public SpriteRenderer markerCircle;
    protected override void Awake()
    {
        base.Awake();
        weapon = transform.GetChild(0).GetComponent<Weapon>();
        bob = Player.FindObjectOfType<Player>();
        markerCircle.color = new Color(0, 1, 0, 0);


    }

    private void Start()
    {
        //target = Player.targetTest;
    }

    // Update is called once per frame
    protected override void Update()
    {
       
        base.Update();

        //Debug.Log(desiredPosition);
        //Desired rotation is currently set all the way back in mobile

        if (Mathf.Abs(DesiredRotation()) < 1 && target != null)
        {
            if(target.TryGetComponent<Unit>(out Unit u)) //another messy getComponent action
            {
                if (u.allegiance != 0 && u.allegiance != allegiance) StandardAttack(); //If the unit isn't a "neutral" and isn't of the same faction, shoot.
            }
        }
        if (marked) markerCircle.color = new Color(0, 1, 0, 0.8f);
        else if (!marked) markerCircle.color = new Color(0, 1, 0, 0);


        //if close to desired rotation turn slowly
        if (DesiredRotation() > 0) rb.angularVelocity = 1f;
        if (DesiredRotation() < 0) rb.angularVelocity = -1f;

        //if far from desired rotation turn fast
        if (DesiredRotation() > 2) rb.angularVelocity = 100;
        if (DesiredRotation() < -2) rb.angularVelocity = -100;

        if ((desiredPosition-transform.position).magnitude > 2)
        {
            rb.velocity = movementVector * speed * (Mathf.Max(0.5f, 1 - (Vector2.Angle(transform.up, movementVector))/180)); //infantry moves slower if they aren't looking where they are going
            
        }
        else
        {
            rb.velocity = Vector2.zero;
            //rb.angularVelocity = 0f;
        }

    }

    public void StandardAttack() //where the unit should try to call it's gun or other Object in order to attack;
    {
        weapon.Fire(((Vector2)(transform.position - target.position)).magnitude, 5f + MapGenerator.GetTerrainModifier(target.position.x,target.position.y));
        //weapon.Fire(target.position, 1, allegiance);
    }
    void PickUpGun() {
        
    }

    public override float DesiredRotation() //the difference between where the unit is looking and where it "wants" to be looking
    {
        if (target == null) return Vector2.SignedAngle(transform.up, desiredPosition - transform.position);
        if (target.TryGetComponent<Unit>(out Unit bob))
        {
            if (isInRange() && allegiance != bob.allegiance && bob.allegiance != 0) return Vector2.SignedAngle(transform.up, target.position - transform.position);

        }
        return Vector2.SignedAngle(transform.up, desiredPosition - transform.position);
    }

    

    public void EnterInterior(Tonk t)
    {
        rb.simulated = false;
    }

    public void ExitInterior(Tonk t)
    {
        rb.simulated = true;
    }

    public override void CheckHealth()
    {
        if (health <= 0)
        {
            ParticleManager.SpawnCorpse(transform.position, 1, 1);

            if (allegiance == 1)
            {
                Barracks.SetNumberOfAllies(Barracks.GetNumberOfAllies() - 1);
                casualties++;
            }
        }
        base.CheckHealth();
    }
}
