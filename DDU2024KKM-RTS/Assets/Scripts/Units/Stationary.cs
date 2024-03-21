using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary : Unit
{
    
    
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        isStationary = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }


}
