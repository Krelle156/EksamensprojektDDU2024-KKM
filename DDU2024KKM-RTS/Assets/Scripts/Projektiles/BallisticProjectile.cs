using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticProjectile : Projectile
{
    [SerializeField] protected SmokeParticle smoke;
    protected SmokeParticle[] smokeList;
    protected int smokeCount;
    protected float smokeCoolDown, smokeCoolMax = 0.05f;

    [SerializeField] protected Sprite up, down;

    private void Awake()
    {
        smokeList = new SmokeParticle[20];
        for (int i = 0; i < smokeList.Length; i++)
        {
            smokeList[i] = Instantiate(smoke,transform.position,Quaternion.identity);
        }
        //rb = GetComponent<Rigidbody2D>();
    }

    void Start()
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
            smokeList[smokeCount].spawn(transform.position-transform.up*1f + new Vector3(0,0,1), 1, (2f - (Mathf.Abs(flightDistance) / maxFlightDistance)) * 0.1f);
            smokeCount++;
            if (smokeCount >= smokeList.Length) smokeCount = 0;
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
        for(int i=0; i<smokeList.Length;i++)
        {
            Destroy(smokeList[i].gameObject);
        }
        CameraController.boomTempTest.spawn(transform.position,0.25f,3f);
        Destroy(gameObject);
    }
}
