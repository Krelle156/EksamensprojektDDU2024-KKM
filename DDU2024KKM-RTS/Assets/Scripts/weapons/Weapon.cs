using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Projectile bullet, tempBullet;
    protected int firerateRPM, ammunition;
    protected float range;
    protected float explosivePower, kinecticDamage, armorPiercing;
    protected float maxcool = 1, cool = 0;
    protected float muzzleFlashTimer = 0;

    protected float spread = 5f;
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

    public void Fire()
    {
        if (cool <= 0)
        {
            cool = maxcool;
            muzzleFlashTimer = maxcool;
            tempBullet = Instantiate(bullet, transform.position, transform.rotation);
            tempBullet.transform.Rotate(new Vector3(0, 0, 1), Random.Range(-spread, spread));
            tempBullet.SetAllegiance(GetComponentInParent<Unit>().allegiance);
        }
    }

    protected virtual void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            //Fire();
            //Debug.Log("Fire");
        }
    }





}
