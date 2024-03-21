using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AIScript : MonoBehaviour
{
    protected Infantry agent;
    protected Tonk vehicle;

    protected Transform target;
    protected Vector3 desiredPosition;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float DesiredRotation() //the difference between where the unit is looking and where it "wants" to be looking
    {
        if (isInRange()) return Vector2.SignedAngle(transform.up, target.position - transform.position);
        else if (target == null) return Vector2.SignedAngle(transform.up, desiredPosition - transform.position);
        return 0;
    }

    public void SetWaypoint(Vector3 v)
    {
        //The coordinate the unit will try to reach through a straight line
        //(in case of pathfinding this would be a node on the way to the actual target)
        desiredPosition = v;
    }

    public void RemoveWaypoint() //In case the unit doesn't need to change it's position
    {
        desiredPosition = transform.position;
    }

    protected bool isInRange()
    {
        return true;
    }
}
