using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TileData 
{
    float treeValue;
    // Start is called before the first frame update
    public void UpdateTreeValue(float tree) {
        treeValue += tree;
        Debug.Log(treeValue);
    }

    

    public float GetTerrainModifier()
    {
        return treeValue;
    }


}
