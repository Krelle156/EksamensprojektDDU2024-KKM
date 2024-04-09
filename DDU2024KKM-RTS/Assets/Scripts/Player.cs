using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class Player : MonoBehaviour
{
    public Transform waypoint, tempwaypoint;

    public List<Unit> units;
    protected Unit currentUnit;

    int allegiance;
    //public static Transform targetTest;
    [SerializeField] protected Sprite genericMouse, target, selector;
    protected SpriteRenderer spriteRenderer;
    protected int cursorMode = 0;

    public Transform barracksObject;

    // Start is called before the first frame update
    private void Start()
    {
        allegiance = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        selector = spriteRenderer.sprite;
    }

    void Awake()
    {
        Cursor.visible = false;
    }

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.TryGetComponent<Unit>(out Unit bob))
        {
            if (collisionInfo.GetComponent<Unit>().marked == false && allegiance == collisionInfo.GetComponent<Unit>().allegiance && cursorMode == 1)
            {
            
                units.Add(collisionInfo.GetComponent<Unit>());
                collisionInfo.GetComponent<Unit>().marked = true;
                currentUnit = collisionInfo.GetComponent<Unit>();
            
            }
            currentUnit = collisionInfo.GetComponent<Unit>();
        }
    }

    private void OnTriggerExit2D(Collider2D collisionInfo)
    {
        if (collisionInfo.TryGetComponent<Unit>(out Unit bob))
        {
            if (bob == currentUnit)
            {
                currentUnit = null;
                
            }
                

            if (collisionInfo.GetComponent<Unit>().marked == true && allegiance == collisionInfo.GetComponent<Unit>().allegiance && cursorMode == 1)
            {

                units.Add(collisionInfo.GetComponent<Unit>());
                collisionInfo.GetComponent<Unit>().marked = false;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float mousePosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        spriteRenderer.transform.localScale = new Vector3(Camera.main.orthographicSize / 10, Camera.main.orthographicSize / 10, 1);

        if (currentUnit != null)
        {
            if (currentUnit.allegiance != allegiance && currentUnit.allegiance > 0)
            {
                if(cursorMode == 0) //only switch from the generic cursor (reconsider if we want more cursors)
                {
                    cursorMode = 2;
                    spriteRenderer.sprite = target;
                    spriteRenderer.color = new Color(1, 0, 0, 1);
                    
                }

                if(Input.GetMouseButtonDown(1))
                {
                    for (int i = 0; i < units.Count; i++)
                    {
                        units[i].setTarget(currentUnit.transform);
                    }
                }

            }   else if (cursorMode == 2) //only if we have just been in marked mode should we switch back to the generic cursor
            {
                cursorMode = 0;
                spriteRenderer.sprite = genericMouse;
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }
        } else if (cursorMode == 2) //only if we have just been in marked mode should we switch back to the generic cursor
        {
            cursorMode = 0;
            spriteRenderer.sprite = genericMouse;
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }

        //GetComponent<Collider2D>().enabled = false;
        if (Input.GetMouseButtonDown(0))
        {   
            for (int i = 0; i < units.Count; i++)
            {
                units[i].marked = false;
            }
            units.Clear();

            if (cursorMode != 1) //if we aren't showint the selector box, switch the sprite, otherwise do nothing
            {
                cursorMode = 1;
                spriteRenderer.sprite = selector;
                spriteRenderer.color = new Color(1, 1, 1, 0.2f);
            }

        };
        if (Input.GetMouseButton(0))
        {
            //GetComponent<Collider2D>().enabled = true;
            transform.localScale = new Vector2(mousePosX - transform.position.x, transform.position.y - mousePosY);

            
        }
        else
        {
            transform.position = new Vector3(mousePosX, mousePosY,-9);
            
        }
        if (Input.GetMouseButtonUp(0)) // If we stop trying to select Units we should go back to "normal"
        {
            if (cursorMode != 0) // change the cursor back to the generic variant if it is not already
            {
                cursorMode = 0;
                spriteRenderer.sprite = genericMouse;
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }
            transform.localScale = new Vector2(1, 1); //standard size
        }

        if (units.Count > 0 && cursorMode != 2) //Don't place a waypoint if there are no selected units or if you are trying to tell them to attack
        {
            if (Input.GetMouseButtonDown(1))
            {
                for (int i = 0; i < units.Count; i++)
                {

                    units[i].SetWaypoint(new Vector3(mousePosX, mousePosY, -2f)); //should be done by the waypoint itself
                    tempwaypoint=Instantiate(waypoint, new Vector3(mousePosX, mousePosY, -2f), Quaternion.identity); //Places a waypoint at the position of the mouse click
                    tempwaypoint.GetComponent<WaypointScript>().units.Add(units[i]);
                    if (units[i].wayPoint != null) units[i].wayPoint.GetComponent<WaypointScript>().units.Remove(units[i]);
                    units[i].wayPoint = tempwaypoint;
                    
                    // Debug.Log(units.Count);

                }
            }

        }

        //Remove cursor if the game is in focus
        if (UnityEngine.Application.isFocused == true) Cursor.visible = false;

    }
}
