using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ptrs41 : Gun
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        firerateRPM = 5;
        ammunition = 1;
        range = 100;
        explosivePower = 0;
        armorPiercing = 3;
        maxcool = 60/ firerateRPM;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
