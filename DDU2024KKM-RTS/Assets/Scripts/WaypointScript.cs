using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Waypoint_Script : MonoBehaviour
{
    public List<Transform> units;
    public List<Mobile> mobiles;
    private int UnitsAtPosition = 0;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i > mobiles.Count; i++)
        {
            mobiles[i].SetWaypoint(transform.position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Deleting the waypoint if all the units have reached it
        if (UnitsAtPosition == units.Count) Destroy(gameObject); 
       
    }

   

    
}
