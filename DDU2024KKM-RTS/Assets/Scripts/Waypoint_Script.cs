using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Waypoint_Script : MonoBehaviour
{
    public List<Transform> units;
    private int UnitsAtPosition = 1;

    // Start is called before the first frame update
    void Start()
    {
        MakeSmallWayPoints();
    }

    // Update is called once per frame
    void Update()
    {
        if (UnitsAtPosition == units.Count) Destroy(gameObject); 
       
    }

    private void MakeSmallWayPoints()
    {
        for (int i=0;i<units.Count;i++) {
        
        }
    }




}
