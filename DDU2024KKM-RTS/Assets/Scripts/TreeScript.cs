using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeScript : Stationary
{
    int tree=5; //base tree value (at least for this "type" of tree)
    protected override void Awake()
    {
        base.Awake();
        spreadTreeValue();//When the tree is created, inform surrounding tiles with decreasing strength
        MapGenerator.terraindata[(int)transform.position.x, (int)transform.position.y].GetTerrainModifier();
    }
    void Start()
    {
        
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void CheckHealth()
    {
        if (health <= 0) DestroyTree();
    }

    public void spreadTreeValue() //for spreading the tree's value from the center
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
        MapGenerator.terraindata[(int)transform.position.x, (int)transform.position.y].UpdateTreeValue(10000);//Absurdly high tree value to tell the pathfinding that there is a tree-hitbox here

    }

    public void DestroyTree() //remove the tree and retract its value
    {
        for (int i = (int)transform.position.x - tree; i < ((int)transform.position.x + tree); i++)
        {
            for (int j = (int)transform.position.y - tree; j < ((int)transform.position.y + tree); j++)
            {
                if (i >= 0 && j >= 0 && i < MapGenerator.getMapWidth() && j < MapGenerator.getMapHeight()) //Checks if we are asking for something inside of the "map" bounds
                {
                    MapGenerator.terraindata[i, j].UpdateTreeValue(-(tree - Mathf.Min(Mathf.Abs(i - transform.position.x) + Mathf.Abs(j - transform.position.y), tree))); //Mathf.Max ensures no negative numbers
                }
            }
        }
        MapGenerator.terraindata[(int)transform.position.x, (int)transform.position.y].UpdateTreeValue(-10000);//Removes absurdly high treevalue
        Destroy(gameObject);
    }
}
