using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    protected int firerateRPM, ammunition;
    protected float range;
    protected float explosivePower, kinecticDamage, armorPiercing;
    protected float maxcool = 1, cool = 0;
    protected virtual void Awake()
    {

    }

    public int getfr (){
        return firerateRPM;
    }

    public float getammunition()
    {
        return ammunition;
    }

    public float getrange()
    {
        return range;
    }

    public float getexplosivePower()
    {
        return explosivePower;
    }

    public float getkineticDamage()
    {
        return kinecticDamage;
    }

    public float getarmorPiercing()
    {
        return armorPiercing;
    }




    
}
