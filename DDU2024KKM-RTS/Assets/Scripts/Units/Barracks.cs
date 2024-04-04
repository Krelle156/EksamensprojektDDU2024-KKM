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
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        //Debug.Log(marked);
       
        if (Input.GetKeyDown(KeyCode.K)) {

            troopInstance = Instantiate(artroop, transform.position, Quaternion.identity);
            troopInstance.GetComponent<Infantry>().SetWaypoint(desiredPosition);
            troopInstance.GetComponent<Infantry>().allegiance = 1;
            Debug.Log("im on team " + troopInstance.GetComponent<Infantry>().allegiance);
            desiredPosition = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            troopInstance = Instantiate(artroop, transform.position, Quaternion.identity);
            troopInstance.GetComponent<Infantry>().SetWaypoint(desiredPosition);
            troopInstance.GetComponent<Infantry>().allegiance = 2;
            Debug.Log("im on team " + troopInstance.GetComponent<Infantry>().allegiance);
            desiredPosition = transform.position;
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
