using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Barracks : Stationary
{
    // Start is called before the first frame update
    public Transform artroop, smgtroop, attroop;
    private Transform troopInstance;
    int priceAR, priceSMG, priceAT;
    int i;

    protected override void Awake()
    {
        base.Awake();
        //troopInstance = Instantiate(artroop, new Vector3(0, 0), Quaternion.identity);
        //troopInstance.GetComponent<Infantry>().SetWaypoint(desiredPosition);
        //Instantiate(smgtroop, new Vector3(0, 1), Quaternion.identity);
        //Instantiate(attroop, new Vector3(-1, 1), Quaternion.identity);
        health = 1000000;
        
    }

    private void Start()
    {
        desiredPosition = transform.position;

        if (this.allegiance == 2)
        {
            for (int i = 0; i < 10; i++)
            {
                float ranNum = Random.Range(-0.1f, 0.1f);
                troopInstance = Instantiate(artroop, new Vector2(transform.position.x + ranNum, transform.position.y + ranNum), Quaternion.identity);
                troopInstance.GetComponent<Infantry>().SetWaypoint(desiredPosition);
                troopInstance.GetComponent<Infantry>().allegiance = 2;
                Debug.Log("im on team " + troopInstance.GetComponent<Infantry>().allegiance);
            }
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        //Debug.Log(marked);
       
        if (Input.GetKeyDown(KeyCode.K) && this.allegiance == 1) {

            troopInstance = Instantiate(artroop, transform.position, Quaternion.identity);
            troopInstance.GetComponent<Infantry>().SetWaypoint(desiredPosition);
            troopInstance.GetComponent<Infantry>().allegiance = 1;
            Debug.Log("im on team " + troopInstance.GetComponent<Infantry>().allegiance);
        }

        if (Input.GetKeyDown(KeyCode.L) && this.allegiance == 2)
        {
            troopInstance = Instantiate(artroop, transform.position, Quaternion.identity);
            troopInstance.GetComponent<Infantry>().SetWaypoint(desiredPosition);
            troopInstance.GetComponent<Infantry>().allegiance = 2;
            Debug.Log("im on team " + troopInstance.GetComponent<Infantry>().allegiance);
        }
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
