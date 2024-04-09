using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Mobile
{
    [SerializeField] protected BallisticProjectile rocket;
    int rockets = 12;
    float coolDown, maxCoolDown;
    float spread = 10;
    
    protected override void Awake()
    {
        base.Awake();
        maxCoolDown = 0.25f;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (coolDown > 0) coolDown -= 1*Time.deltaTime;
        fire(); //currently fires just whenever


    }

    protected void fire()
    {
        if (coolDown <= 0 && rockets>0)
        {
            rockets--;
            Instantiate(rocket, transform.position, Quaternion.Euler(0,0, transform.rotation.z+Random.Range(-spread,spread)));
            coolDown = maxCoolDown;
        }
    }
}
