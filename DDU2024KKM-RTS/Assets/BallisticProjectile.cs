using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticProjectile : MonoBehaviour
{
    float flightDistance = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(1f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (flightDistance > 0)
        {
            flightDistance -= GetComponent<Rigidbody2D>().velocity.magnitude*Time.deltaTime;
        } else if (flightDistance <= 0) GetComponent<Rigidbody2D>().velocity =Vector2.zero;


    }

    void FixedUpdate()
    {

    }
}
