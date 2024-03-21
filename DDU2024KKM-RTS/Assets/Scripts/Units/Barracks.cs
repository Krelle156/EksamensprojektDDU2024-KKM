using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : Stationary
{
    // Start is called before the first frame update
    public Transform artroop, smgtroop, attroop,temp;
    int priceAR, priceSMG, priceAT;
    int i;
    

    protected override void Awake()
    {
        base.Awake();
        temp=Instantiate(artroop, new Vector3(1, 1), Quaternion.identity);
        temp.GetComponent<Infantry>().SetWaypoint(desiredPosition);
        Instantiate(smgtroop, new Vector3(0, 1), Quaternion.identity);
        Instantiate(attroop, new Vector3(-1, 1), Quaternion.identity);
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        Debug.Log(marked);
       
        if (Input.GetKey("k")) {

            temp = Instantiate(artroop, new Vector3(1, 1), Quaternion.identity);
            temp.GetComponent<Infantry>().SetWaypoint(desiredPosition);
        }
    }

    bool resources(){
        if (3==3) {
            return false;
        }
        return true;
    }
}
