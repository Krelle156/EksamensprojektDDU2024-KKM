using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : Projectile
{
    float strength = 1;
    // Start is called before the first frame update

    // Update is called once per frame

    public override void Launch(float dist, Vector2 direction, float spread)
    {
        base.Launch(dist, direction, spread);
        flightDistance = dist + 10f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Unit>(out Unit bob))
        {
            if(bob.allegiance != allegiance && bob.allegiance != 0)
            {
                Impact();
                bob.damage(strength, 0.1f);
                bob.CheckHealth();
            }
        }
    }

}
