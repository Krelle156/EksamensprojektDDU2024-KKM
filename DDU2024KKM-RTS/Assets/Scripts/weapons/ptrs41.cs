using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ptrs41 : Gun
{
    public SpriteRenderer mundingsglimttemp;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        firerateRPM = 5;
        ammunition = 1;
        range = 100;
        explosivePower = 0;
        armorPiercing = 3;
        maxcool = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (cool > 0)
        {
            cool -= 1 * Time.deltaTime;
            mundingsglimttemp.color = new Color(1, 1, 1, cool / maxcool);
        }
    }
}
