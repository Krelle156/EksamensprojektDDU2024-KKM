using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public abstract class Unit : MonoBehaviour
{
    protected int type;
    protected float health, maxHealth, armor;
    protected Transform target;
    protected Rigidbody2D rb;

    public Transform wayPoint;
    public bool marked;
    public int allegiance;

    public Transform targetTest;


    // Start is called before the first frame update
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        marked = false;
        target = targetTest;
        //TODO - make work!
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        

    }

    
}
