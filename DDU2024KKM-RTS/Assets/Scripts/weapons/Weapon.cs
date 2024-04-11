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

    float startDirection;
    protected float maxRotation = 2.5f;

    [SerializeField] protected AudioSource audioSource;

    protected float spread = 5f;
    protected virtual void Awake()
    {
        startDirection = transform.localEulerAngles.z;
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

    public void Fire(float range, float accuracy)
    {
        if (cool <= 0)
        {
            cool = maxcool;
            muzzleFlashTimer = maxcool;
            tempBullet = Instantiate(bullet, transform.position, transform.rotation);
            tempBullet.Launch(range, transform.up, 5f+accuracy);
            tempBullet.SetAllegiance(GetComponentInParent<Unit>().allegiance);

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    public void Fire(Vector2 target, Vector2 up, float accuracy, int allegiance)
    {
        float tempAngle = Vector2.SignedAngle(transform.up, target - (Vector2)transform.position);
        float tempAngle2 = Vector2.SignedAngle(transform.up, up);
        Debug.Log(transform.up);
        Debug.Log(GetComponentInParent<Transform>().up);
        ;
        
        if (tempAngle < 0 && tempAngle2 > -maxRotation) transform.Rotate(new Vector3(0, 0, -1));
        if (tempAngle > 0 && tempAngle2 < maxRotation) transform.Rotate(new Vector3(0, 0, 1));

        if (cool <= 0)
        {
            cool = maxcool;
            muzzleFlashTimer = maxcool;
            tempBullet = Instantiate(bullet, transform.position, transform.rotation);
            tempBullet.Launch(((Vector2)transform.position-target).magnitude, transform.up, 5f + accuracy);
            tempBullet.SetAllegiance(allegiance);

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    protected virtual void Update()
    {
        
    }





}
