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
    
    public bool isStationary=false;
    public Transform wayPoint;
    public bool marked;
    public int allegiance;
    protected Vector3 desiredPosition;




    // Start is called before the first frame update
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        marked = false;
        target = Player.targetTest;
        //TODO - make work!
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        

    }

    public void SetWaypoint(Vector3 v)
    {
        //The coordinate the unit will try to reach through a straight line
        //(in case of pathfinding this would be a node on the way to the actual target)
        desiredPosition = v;
    }




}
