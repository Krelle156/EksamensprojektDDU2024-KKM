using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : Projectile
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Unit>(out Unit bob))
        {
            if(bob.allegiance != allegiance && bob.allegiance != 0)
            {
                Destroy(gameObject);
                bob.checkHealth();
            }
        }
    }
}