using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPlacer : MonoBehaviour
{
    public Transform waypoint;

    public Transform Units; //testvalue - should be a list whose elements should be able to be chosen by the player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float mousePosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;


        if (Input.GetMouseButtonDown(0))
        {
            Units.GetComponent<Mobile>().SetWaypoint(new Vector2(mousePosX, mousePosY)); //should be done by the waypoint itself
            Instantiate(waypoint, new Vector2(mousePosX, mousePosY), Quaternion.identity); //Places a waypoint at the position of the mouse click
            //Debug.Log(waypoint.position);
        }
    }
}
