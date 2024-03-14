using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeScript : Stationary
{

    // Start is called before the first frame update
    private void Awake()
    {
        spreadTreeValue(5);
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

    public void spreadTreeValue(float tree)
    {
        for (int i = (int)transform.position.x - 5; i > ((int)transform.position.x + 5);i++)
        {
            for (int j = (int)transform.position.y - 5; j > ((int)transform.position.y + 5); j++)
            {
                if(i>0&&j>0&&i<MapGenerator.getMapWidth()&&j<MapGenerator.getMapHeight())
                {
                    MapGenerator.terraindata[i, j].UpdateTreeValue(tree-Mathf.Abs(i-transform.position.x)-Mathf.Abs(j-transform.position.y));
                }
            }
        }
    }
}
