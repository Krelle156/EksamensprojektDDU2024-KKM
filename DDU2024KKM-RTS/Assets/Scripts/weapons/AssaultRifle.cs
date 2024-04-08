using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    public SpriteRenderer muzzleFlashSprite;
    // Start is called before the first frame update
    protected override void Awake()
    {
        
        base.Awake();
        firerateRPM = 600;
        ammunition = 30;
        range = 30;
        explosivePower = 0;
        armorPiercing = 0;
        maxcool = 1;
        muzzleFlashSprite.color = new Color(1, 1, 1, 0);
        



    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (cool>0) 
        {
            cool -= 1 * Time.deltaTime;
            muzzleFlashTimer -= 10 * Time.deltaTime;
            muzzleFlashSprite.color = new Color(1, 1, 1, muzzleFlashTimer / maxcool);
        }
        

    }

    
}
