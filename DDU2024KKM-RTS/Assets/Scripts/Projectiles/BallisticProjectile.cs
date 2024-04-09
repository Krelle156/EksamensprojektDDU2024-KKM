using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticProjectile : Projectile
{
    List<Collider2D> tempList;
    protected float smokeCoolDown, smokeCoolMax = 0.05f;

    [SerializeField] protected Sprite up, down;

    private void Awake()
    {

        //rb = GetComponent<Rigidbody2D>();
    }

    protected override void Start()
    {
        GetComponent<SpriteRenderer>().sprite = up;
        GetComponent<Rigidbody2D>().velocity = transform.up * 15;
    }

    void Update()
    {
        if (flightDistance > -maxFlightDistance / 2)
        {
            transform.localScale = new Vector3(2f - (Mathf.Abs(flightDistance) / maxFlightDistance) * 1.2f, ((2f - (Mathf.Abs(flightDistance) / maxFlightDistance) * 1.2f) * (1 - (Mathf.Abs(flightDistance) / maxFlightDistance) * 0.9f)), 1);
            if (flightDistance < 0)
            {
                GetComponent<SpriteRenderer>().sprite = down;

            }
            flightDistance -= rb.velocity.magnitude * Time.deltaTime;
        }
        //else if (flightDistance <= 0) GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        else if (flightDistance <= 0) GroundImpact();

        if(smokeCoolDown<=0 && flightDistance >0)
        {
            ParticleManager.SpawnSmoke(transform.position-transform.up*1f + new Vector3(0,0,1), 1, (2f - (Mathf.Abs(flightDistance) / maxFlightDistance)) * 0.1f);
            smokeCoolDown = smokeCoolMax;
        }
        smokeCoolDown -= 1*Time.deltaTime;

    }

    void FixedUpdate()
    {

    }

    public override void Launch(float dist, Vector2 direction)
    {
        base.Launch(dist, direction);
        flightDistance = dist / 2;
    }

    protected override void GroundImpact()
    {
        Collider2D[] tempList = Physics2D.OverlapCircleAll((Vector2)transform.position, 10);
        for(int i = 0; i<tempList.Length ; i++)
        {
            if(tempList[i].TryGetComponent(out Unit unit))
            {
                unit.damage(10);
            }
        }
        base.GroundImpact();
    }

}
