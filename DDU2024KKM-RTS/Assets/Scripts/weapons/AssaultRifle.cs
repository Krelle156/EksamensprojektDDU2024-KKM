using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : gun
{
    public Transform mundingsglimttemp;
    // Start is called before the first frame update
    void Start()
    {
        
        base.Awake();
        firerateRPM = 600;
        ammunition = 30;
        range = 30;
        explosivePower = 0;
        armorPiercing = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (cool>0) 
        {
            cool -= 1 * Time.deltaTime;
            mundingsglimttemp.GetComponent<SpriteRenderer>().color = new Color(1,1,1,cool/maxcool);
        }
        

    }

    public void Fire() {
        if (cool <= 0) {
            cool = maxcool;
        }
        Debug.Log("hi");

    }
}
