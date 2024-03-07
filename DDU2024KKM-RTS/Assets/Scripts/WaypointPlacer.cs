using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPlacer : MonoBehaviour
{
    public Transform waypoint;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hi");
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float mousePosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(waypoint, new Vector2(mousePosX, mousePosY), Quaternion.identity);
            //Debug.Log(waypoint.position);
        }
    }
}
