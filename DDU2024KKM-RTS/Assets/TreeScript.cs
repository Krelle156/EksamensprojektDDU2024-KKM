using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeScript : Stationary
{

    // Start is called before the first frame update
    private void Awake()
    {
        MapGenerator.terraindata[(int)transform.position.x, (int)transform.position.y].UpdateTreevalue(Random.Range(0, 10));
        Debug.Log("Position = (" + transform.position.x + " ; " + transform.position.y + ")");
        MapGenerator.terraindata[(int)transform.position.x, (int)transform.position.y].GetTerrainModifier();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
