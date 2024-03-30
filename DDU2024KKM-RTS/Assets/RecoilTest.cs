using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilTest : MonoBehaviour
{
    float timer, maxTime = 2;
    Vector2 gunPos = new Vector2 (0,1.453f);
    Vector2 recoilSpeed = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (timer > 0)
        {
            
            if (timer > maxTime/2 )
            {
                timer -= 10 * Time.fixedDeltaTime;
                transform.localPosition = gunPos - Vector2.up * ((maxTime / 2)-(timer - (maxTime / 2)));
            } else
            {
                timer -= 1 * Time.fixedDeltaTime;
                transform.localPosition = Vector2.SmoothDamp(transform.localPosition ,gunPos, ref recoilSpeed, 0.5f);
            }
                
        }
        else if(Input.GetKey("t")) timer = maxTime; //only for testing
    }
}
