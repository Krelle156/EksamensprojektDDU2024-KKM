using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform waypoint;
    public List<Transform> units; //testvalue - should be a list whose elements should be able to be chosen by the player

    // Start is called before the first frame update
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {

    }

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        units.Add(collisionInfo.GetComponent<Transform>());
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
        if (Input.GetMouseButtonDown(0)) units.Clear();
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
                    units[i].GetComponent<Mobile>().SetWaypoint(new Vector2(mousePosX, mousePosY)); //should be done by the waypoint itself
                    Instantiate(waypoint, new Vector2(mousePosX, mousePosY), Quaternion.identity); //Places a waypoint at the position of the mouse click
                    //Debug.Log(waypoint.position);

                }
            }

        }

    }
}
