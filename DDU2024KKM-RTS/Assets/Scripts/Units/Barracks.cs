using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform artroop, smgtroop, attroop;
     
    void Start()
    {
        Instantiate(artroop, new Vector3(1,1),Quaternion.identity);
        Instantiate(smgtroop, new Vector3(0, 1), Quaternion.identity);
        Instantiate(attroop, new Vector3(-1, 1), Quaternion.identity);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
