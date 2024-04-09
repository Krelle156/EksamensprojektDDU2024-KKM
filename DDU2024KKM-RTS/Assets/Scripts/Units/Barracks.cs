using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Barracks : Stationary
{
    // Start is called before the first frame update
    public Transform artroop, smgtroop, attroop;
    private Transform troopInstance;
    public Transform tonk;
    private Transform tonkInstance;
    int priceAR, priceSMG, priceAT;
    int i;

    protected override void Awake()
    {
        base.Awake();
        
        health = 1000000;
        
    }

    private void Start()
    {

        if (this.allegiance == 2)
        {
            for (int i = 0; i < 100; i++)
            {
                float ranX = Random.Range(-10f, 10f);
                float ranY = Random.Range(-10f, 10f);
                troopInstance = Instantiate(artroop, new Vector2(transform.position.x + ranX, transform.position.y + ranX), Quaternion.identity);
                desiredPosition = new Vector2(transform.position.x + ranX, transform.position.y + ranY);
                troopInstance.GetComponent<Infantry>().SetWaypoint(desiredPosition);
                troopInstance.GetComponent<Infantry>().allegiance = 2;

                
                //Debug.Log("im on team " + troopInstance.GetComponent<Infantry>().allegiance);
            }

            tonkInstance = Instantiate(tonk, new Vector2(transform.position.x, transform.position.y + 10f), Quaternion.identity);
            desiredPosition = new Vector2(transform.position.x, transform.position.y + 10f);
            tonkInstance.GetComponent<Tonk>().transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90f);
            tonkInstance.GetComponent<Tonk>().SetWaypoint(desiredPosition);
            tonkInstance.GetComponent<Tonk>().allegiance = 2;
        }

        if (this.allegiance == 1)
        {
            tonkInstance = Instantiate(tonk, new Vector2(transform.position.x, transform.position.y + 10f), Quaternion.identity);
            desiredPosition = new Vector2(transform.position.x, transform.position.y + 10f);
            tonkInstance.GetComponent<Tonk>().transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90f);
            tonkInstance.GetComponent<Tonk>().SetWaypoint(desiredPosition);
            tonkInstance.GetComponent<Tonk>().allegiance = 1;
        }

    }

    // Update is called once per frame
    protected override void Update()
    {
        //Debug.Log(marked);
        float ranX = Random.Range(-10f, 10f);
        float ranY = Random.Range(-10f, 10f);

        if (Input.GetKeyDown(KeyCode.Space) && this.allegiance == 1) 
        {
            troopInstance = Instantiate(artroop, transform.position, Quaternion.identity);
            desiredPosition = new Vector2(transform.position.x + ranX, transform.position.y + ranY);
            troopInstance.GetComponent<Infantry>().SetWaypoint(desiredPosition);
            troopInstance.GetComponent<Infantry>().allegiance = 1;

            //Debug.Log("im on team " + troopInstance.GetComponent<Infantry>().allegiance);
        }
        
        /*
        if (Input.GetKeyDown(KeyCode.L) && this.allegiance == 2)
        {
            troopInstance = Instantiate(artroop, transform.position, Quaternion.identity);
            desiredPosition = new Vector2(transform.position.x + ranX, transform.position.y + ranY);
            troopInstance.GetComponent<Infantry>().SetWaypoint(desiredPosition);
            troopInstance.GetComponent<Infantry>().allegiance = 2;
            Debug.Log("im on team " + troopInstance.GetComponent<Infantry>().allegiance);
        }
        */
    }

    private void barrackColor()
    {

    }


    /*
    bool resources(){
        if (3==3) {
            return false;
        }
        return true;
    }
    */
}
