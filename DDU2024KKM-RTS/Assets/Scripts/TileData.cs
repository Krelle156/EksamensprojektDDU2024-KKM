using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TileData 
{
    float treeValue = 0;
    // Start is called before the first frame update
    public void UpdateTreeValue(float tree) {
        treeValue += tree;

    }

    

    public float GetTerrainModifier()
    {
        return treeValue;
    }


}
