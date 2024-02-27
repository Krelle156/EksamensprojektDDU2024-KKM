using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonk : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        type = 69;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(type);
    }
}
