using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TileData 
{
    float treeValue = 0; //As a result of the tree's algorithm, it cannot be decimals, should be discussed at some point
    // Start is called before the first frame update
    public void UpdateTreeValue(float tree) {
        treeValue += tree;//adds to the existing treevalue.
        treeValue = Mathf.Max(treeValue, 0); //ensures the terrain value is never below 0

    }

    

    public float GetTerrainModifier()
    //currently returns treevalue, unsure of furture naming and purpose
    //should probably be reworked to tell units (with a different function or returned value depending on unit type) what they are modified by
    //meaning the size of the speed modifier (multiplies speed), camuflage modifier (perhaps flat added number instead of multiplier), damage to either health or reliablity and such.
    {
        return treeValue;
    }


}
