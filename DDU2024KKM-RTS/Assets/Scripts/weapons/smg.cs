using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smg : Gun
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        firerateRPM = 900;
        ammunition = 30;
        range = 10;
        explosivePower = 0;
        armorPiercing = 0;
        maxcool = 60 / firerateRPM;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
