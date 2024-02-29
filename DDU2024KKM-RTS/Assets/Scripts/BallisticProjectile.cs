using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticProjectile : MonoBehaviour
{
    float maxFlightDistance = 10;
    float flightDistance = 5;

    public Sprite up, down;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = up;
        GetComponent<Rigidbody2D>().velocity = new Vector2(15f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (flightDistance > -maxFlightDistance / 2)
        {
            transform.localScale = new Vector3(((2f-(Mathf.Abs(flightDistance)/maxFlightDistance)*1.2f)*(1-(Mathf.Abs(flightDistance) / maxFlightDistance)*0.9f)), 2f - (Mathf.Abs(flightDistance) / maxFlightDistance) * 1.2f, 1);
            if (flightDistance < 0)
            {
                GetComponent<SpriteRenderer>().sprite = down;
            
            }
            flightDistance -= GetComponent<Rigidbody2D>().velocity.magnitude * Time.deltaTime;
        }
        else if (flightDistance <= 0) GetComponent<Rigidbody2D>().velocity = Vector2.zero;




    }

    void FixedUpdate()
    {

    }
}
