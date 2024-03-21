using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticProjectile : MonoBehaviour
{
    public SmokeParticle smoke;
    protected SmokeParticle[] smokeList;
    protected int smokeCount;
    protected float smokeCoolDown, smokeCoolMax = 0.05f;


    float maxFlightDistance = 10;
    float flightDistance = 5;

    public Sprite up, down;

    private void Awake()
    {
        smokeList = new SmokeParticle[30];
        for (int i = 0; i < smokeList.Length; i++)
        {
            smokeList[i] = Instantiate(smoke,transform.position,Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = up;
        GetComponent<Rigidbody2D>().velocity = transform.up * 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (flightDistance > -maxFlightDistance / 2)
        {
            transform.localScale = new Vector3(2f - (Mathf.Abs(flightDistance) / maxFlightDistance) * 1.2f,((2f-(Mathf.Abs(flightDistance)/maxFlightDistance)*1.2f)*(1-(Mathf.Abs(flightDistance) / maxFlightDistance)*0.9f)), 1);
            if (flightDistance < 0)
            {
                GetComponent<SpriteRenderer>().sprite = down;
            
            }
            flightDistance -= GetComponent<Rigidbody2D>().velocity.magnitude * Time.deltaTime;
        }
        else if (flightDistance <= 0) GetComponent<Rigidbody2D>().velocity = Vector2.zero;

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
}
