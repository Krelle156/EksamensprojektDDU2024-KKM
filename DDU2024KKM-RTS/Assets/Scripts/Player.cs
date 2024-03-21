using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform waypoint, tempwaypoint;
    public List<Unit> units; //testvalue - should be a list whose elements should be able to be chosen by the player
    int allegiance;
    public static Transform targetTest;

    // Start is called before the first frame update
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        targetTest = transform;
    }

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.GetComponent<Unit>().marked == false && allegiance== collisionInfo.GetComponent<Unit>().allegiance)
        {
            
            units.Add(collisionInfo.GetComponent<Unit>());
            collisionInfo.GetComponent<Unit>().marked = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collisionInfo)
    {
        //units.Remove(collisionInfo.GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {

        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float mousePosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

        GetComponent<Collider2D>().enabled = false;
        if (Input.GetMouseButtonDown(0))
        {   

            for (int i = 0; i < units.Count; i++)
            {
                units[i].marked = false;
            }
            units.Clear();

        };
        if (Input.GetMouseButton(0))
        {
            GetComponent<Collider2D>().enabled = true;
            transform.localScale = new Vector2(mousePosX - transform.position.x, transform.position.y - mousePosY);
        }
        else
        {
            transform.position = new Vector2(mousePosX, mousePosY);
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            transform.localScale = new Vector2(1, 1);
        }

        if (!(units.Count == 0))
        {
            if (Input.GetMouseButtonDown(1))
            {
                for (int i = 0; i < units.Count; i++)
                {

                    units[i].SetWaypoint(new Vector2(mousePosX, mousePosY)); //should be done by the waypoint itself
                    tempwaypoint=Instantiate(waypoint, new Vector2(mousePosX, mousePosY), Quaternion.identity); //Places a waypoint at the position of the mouse click
                    tempwaypoint.GetComponent<WaypointScript>().units.Add(units[i]);
                    if (units[i].wayPoint != null) units[i].wayPoint.GetComponent<WaypointScript>().units.Remove(units[i]);
                    units[i].wayPoint = tempwaypoint;
                    
                    // Debug.Log(units.Count);

                }
            }

        }

    }
}
