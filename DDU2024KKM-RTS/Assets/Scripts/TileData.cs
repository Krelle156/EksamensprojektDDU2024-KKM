using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData 
{
    float treeValue;
    // Start is called before the first frame update
    public void UpdateTreevalue(float tree) {
        treeValue = tree;
        Debug.Log(treeValue);
    }

    public float GetTerrainModifier()
    {
        return treeValue;
    }


}
