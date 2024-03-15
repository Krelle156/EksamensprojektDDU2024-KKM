using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeScript : Stationary
{

    // Start is called before the first frame update
    private void Awake()
    {
        spreadTreeValue(5);//When the tree is created, inform surrounding tiles with decreasing strength
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

    public void spreadTreeValue(int tree)
    {
        for (int i = (int)transform.position.x - tree; i < ((int)transform.position.x + tree);i++)
        {
            for (int j = (int)transform.position.y - tree; j < ((int)transform.position.y + tree); j++)
            {
                if(i>=0 && j>=0 && i<MapGenerator.getMapWidth() && j<MapGenerator.getMapHeight()) //Checks if we are asking for something inside of the "map" bounds
                {
                    MapGenerator.terraindata[i, j].UpdateTreeValue(tree-Mathf.Min(Mathf.Abs(i-transform.position.x)+Mathf.Abs(j-transform.position.y),tree)); //Mathf.Max ensures no negative numbers
                }
            }
        }
    }
}
