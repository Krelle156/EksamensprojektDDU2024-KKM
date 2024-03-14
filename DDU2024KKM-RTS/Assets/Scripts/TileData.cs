using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData 
{
    float TreeValue;
    // Start is called before the first frame update
    public void updatetreevalue(float tree) {
        TreeValue = tree;
        Debug.Log(TreeValue);
    }
}
