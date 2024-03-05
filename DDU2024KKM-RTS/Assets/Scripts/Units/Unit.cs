using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected int type;
    protected float health, maxHealth, armor;
    protected Transform target;
    protected Rigidbody2D rb;


    // Start is called before the first frame update
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //TODO - make work!
    }

    // Update is called once per frame
    void Update()
    {
        //TODO - make work!
    }
}
