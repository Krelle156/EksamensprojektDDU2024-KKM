using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public List<Unit> units;
    
    private int UnitsAtPosition = 0;
    bool isState = false;


    // Start is called before the first frame update
    void Start()
    { 
        for (int i=0;i<units.Count;i++) {
            if (units[i].isStationary == true)
            {
                isState = true;
                units.RemoveAt(i);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        UnitsAtPos();
        //Deleting the waypoint if all the units have reached it
        if (UnitsAtPosition == units.Count && isState==false) Destroy(gameObject);
        
        

    }

    void UnitsAtPos() {
        for (int i=0;i<units.Count;i++) {
            if ((transform.position - units[i].transform.position).magnitude<2)UnitsAtPosition++;
            //Debug.Log(UnitsAtPosition);
        }
    }
    public void marked() { 
        transform.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void destory() { 
        Destroy(gameObject);
    }

   

    
}
