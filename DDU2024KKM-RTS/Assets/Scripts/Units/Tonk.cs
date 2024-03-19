using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonk : Mobile
{
    protected Infantry hullGunner, driver, commander;
    protected Infantry[] crew;

    protected Mobile[] turrets;
    protected Infantry turretGunner;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("køb bananer!");
    }
    void Start()
    {
        
    }

    protected override void Update()
    {
        //base.Update(); currently doesn't have a rigidbody or awake function as such this doesn't work as intended.

    }
}
